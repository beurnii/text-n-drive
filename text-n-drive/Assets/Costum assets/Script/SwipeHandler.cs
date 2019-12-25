using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Lean.Touch
{
    public class SwipeHandler : MonoBehaviour
    {
        /// <summary>Ignore fingers with StartedOverGui?</summary>
        [Tooltip("Ignore fingers with StartedOverGui?")]
        public bool IgnoreStartedOverGui = true;

        /// <summary>Ignore fingers with IsOverGui?</summary>
        [Tooltip("Ignore fingers with IsOverGui?")]
        public bool IgnoreIsOverGui;

        /// <summary>The angle of the arc in degrees that the swipe must be inside.
        /// -1 = No requirement.
        /// 90 = Quarter circle (+- 45 degrees).
        /// 180 = Semicircle (+- 90 degrees).</summary>
        [Tooltip("The angle of the arc in degrees that the swipe must be inside.\n\n-1 = No requirement.\n\n90 = Quarter circle (+- 45 degrees).\n\n180 = Semicircle (+- 90 degrees).")]
        [FormerlySerializedAs("AngleThreshold")]
        public float RequiredArc = 45f;

        [Header("Events")]
        public UnityEvent OnSwipeUp;
        public UnityEvent OnSwipeDown;
        public UnityEvent OnSwipeLeft;
        public UnityEvent OnSwipeRight;

        void OnEnable()
        {
            LeanTouch.OnFingerSwipe += HandleFingerSwipe;
        }


        void OnDisable()
        {
            LeanTouch.OnFingerSwipe -= HandleFingerSwipe;
        }

        private void HandleFingerSwipe(LeanFinger finger)
        {
            if (IgnoreStartedOverGui == true && finger.StartedOverGui == true)
            {
                return;
            }

            if (IgnoreIsOverGui == true && finger.IsOverGui == true)
            {
                return;
            }

            HandleFingerSwipe(finger, finger.StartScreenPosition, finger.ScreenPosition);
        }

        protected bool AngleIsValid(Vector2 vector, int RequiredAngle)
        {
            if (RequiredArc >= 0.0f)
            {
                var angle = Mathf.Atan2(vector.x, vector.y) * Mathf.Rad2Deg;
                var angleDelta = Mathf.DeltaAngle(angle, RequiredAngle);

                if (angleDelta < RequiredArc * -0.5f || angleDelta >= RequiredArc * 0.5f)
                {
                    return false;
                }
            }

            return true;
        }

        void HandleFingerSwipe(LeanFinger finger, Vector2 screenFrom, Vector2 screenTo)
        {
            var finalDelta = screenTo - screenFrom;

            for (int angle = 0; angle < 360; angle = angle + 90)
            {
                if (AngleIsValid(finalDelta, angle) == true)
                {
                    if (angle == 0 && OnSwipeUp != null) OnSwipeUp.Invoke();
                    if (angle == 90 && OnSwipeRight != null) OnSwipeRight.Invoke();
                    if (angle == 180 && OnSwipeDown != null) OnSwipeDown.Invoke();
                    if (angle == 270 && OnSwipeLeft != null) OnSwipeLeft.Invoke();
                }
            }
        }
    }

}
