using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lean.Touch
{
    public class TapHandler : MonoBehaviour
    {
        public enum SearchType
        {
            GetComponent,
            GetComponentInParent,
            GetComponentInChildren
        }

        public enum SelectType
        {
            Manually = -1,
            Raycast3D,
            Overlap2D,
            CanvasUI
        }

        public enum ReselectType
        {
            KeepSelected,
            Deselect,
            DeselectAndSelect,
            SelectAgain
        }

        /// <summary>This stores all active and enabled LeanSelect instances in the scene.</summary>
		public static LinkedList<LeanSelect> Instances = new LinkedList<LeanSelect>();

        /// <summary>Which kinds of objects should be selectable from this component?</summary>
        [Tooltip("Which kinds of objects should be selectable from this component?")]
        public SelectType SelectUsing;

        /// <summary>If SelectUsing fails, you can set an alternative method here.</summary>
        [Tooltip("If SelectUsing fails, you can set an alternative method here.")]
        public SelectType SelectUsingAlt = SelectType.Manually;

        /// <summary>If SelectUsingAlt fails, you can set an alternative method here.</summary>
        [Tooltip("If SelectUsingAlt fails, you can set an alternative method here.")]
        public SelectType SelectUsingAltAlt = SelectType.Manually;

        [Space]

        /// <summary>The layers you want the raycast/overlap to hit.</summary>
        [Tooltip("The layers you want the raycast/overlap to hit.")]
        public LayerMask LayerMask = Physics.DefaultRaycastLayers;

        /// <summary>The camera used to calculate the ray.
        /// None = MainCamera.</summary>
        [Tooltip("The camera used to calculate the ray.\n\nNone = MainCamera.")]
        public Camera Camera;

        /// <summary>How should the candidate GameObjects be searched for the LeanSelectable component?</summary>
        [Tooltip("How should the candidate GameObjects be searched for the LeanSelectable component?")]
        public SearchType Search = SearchType.GetComponentInParent;

        /// <summary>If you select an already selected selectable, what should happen?</summary>
        [Tooltip("If you select an already selected selectable, what should happen?")]
        public ReselectType Reselect = ReselectType.SelectAgain;

        public void SelectStartScreenPosition(LeanFinger finger)
        {
            SelectScreenPosition(finger, finger.StartScreenPosition);
        }

        // NOTE: This must be called from somewhere
        public void SelectScreenPosition(LeanFinger finger)
        {
            SelectScreenPosition(finger, finger.ScreenPosition);
        }

        // NOTE: This must be called from somewhere
        public void SelectScreenPosition(LeanFinger finger, Vector2 screenPosition)
        {
            // Stores the component we hit (Collider or Collider2D)
            var component = default(Component);

            TryGetComponent(SelectUsing, screenPosition, ref component);

            if (component == null)
            {
                TryGetComponent(SelectUsingAlt, screenPosition, ref component);

                if (component == null)
                {
                    TryGetComponent(SelectUsingAltAlt, screenPosition, ref component);
                }
            }

            Select(finger, component);
        }

        private void TryGetComponent(SelectType selectUsing, Vector2 screenPosition, ref Component component)
        {
            switch (selectUsing)
            {
                case SelectType.Raycast3D:
                    {
                        // Make sure the camera exists
                        var camera = LeanTouch.GetCamera(Camera, gameObject);

                        if (camera != null)
                        {
                            var ray = camera.ScreenPointToRay(screenPosition);
                            var hit = default(RaycastHit);

                            if (Physics.Raycast(ray, out hit, float.PositiveInfinity, LayerMask) == true)
                            {
                                component = hit.collider;
                            }
                        } else
                        {
                            Debug.LogError("Failed to find camera. Either tag your cameras MainCamera, or set one in this component.", this);
                        }
                    }
                    break;

                case SelectType.Overlap2D:
                    {
                        // Make sure the camera exists
                        var camera = LeanTouch.GetCamera(Camera, gameObject);

                        if (camera != null)
                        {
                            var point = camera.ScreenToWorldPoint(screenPosition);

                            component = Physics2D.OverlapPoint(point, LayerMask);
                        } else
                        {
                            Debug.LogError("Failed to find camera. Either tag your cameras MainCamera, or set one in this component.", this);
                        }
                    }
                    break;

                case SelectType.CanvasUI:
                    {
                        var results = LeanTouch.RaycastGui(screenPosition, LayerMask);

                        if (results != null && results.Count > 0)
                        {
                            component = results[0].gameObject.transform;
                        }
                    }
                    break;
            }
        }

        public void Select(LeanFinger finger, Component component)
        {
            // Stores the selectable we will search for
            var selectable = default(KeyPressAction);

            // Was a collider found?
            if (component != null)
            {
                switch (Search)
                {
                    case SearchType.GetComponent: selectable = component.GetComponent<KeyPressAction>(); break;
                    case SearchType.GetComponentInParent: selectable = component.GetComponentInParent<KeyPressAction>(); break;
                    case SearchType.GetComponentInChildren: selectable = component.GetComponentInChildren<KeyPressAction>(); break;
                }
            }
            // Select the selectable
            Select(finger, selectable);
        }

        public void Select(LeanFinger finger, KeyPressAction selectable)
        {
            //selectable.Select(finger);
            // Something was selected?
            if (selectable != null && selectable.isActiveAndEnabled == true)
            {
                //if (selectable.HideWithFinger == true)
                //{
                //    foreach (var otherSelectable in KeyPressAction.Instances)
                //    {
                //        if (otherSelectable.HideWithFinger == true && otherSelectable.IsSelected == true)
                //        {
                //            return;
                //        }
                //    }
                //}

                selectable.KeyPress();

                //// Did we select a new LeanSelectable?
                //if (selectable.IsSelected == false)
                //{
                //    // Deselect some if we have too many
                //    if (MaxSelectables > 0)
                //    {
                //        LeanSelectable.Cull(MaxSelectables - 1);
                //    }

                //    // Select
                //}
                //    // Did we reselect the current LeanSelectable?
                //    else
                //    {
                //        switch (Reselect)
                //        {
                //            case ReselectType.Deselect:
                //                {
                //                    selectable.Deselect();
                //                }
                //                break;

                //            case ReselectType.DeselectAndSelect:
                //                {
                //                    selectable.Deselect();
                //                    selectable.Select(finger);
                //                }
                //                break;

                //            case ReselectType.SelectAgain:
                //                {
                //                    selectable.Select(finger);
                //                }
                //                break;
                //        }
                //    }
                //}
                //// Nothing was selected?
                //else
                //{
                //    // Deselect?
                //    if (AutoDeselect == true)
                //    {
                //        DeselectAll();
                //    }
            }
        }
    }
}
