using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetectionScript : MonoBehaviour
{

    public LayerMask touchInputMask;

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchOld;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touchOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchOld);
            touchList.Clear();

            foreach (Touch touch in Input.touches)
            {
                Ray ray = GetComponent<Camera>().ScreenPointToRay(touch.position);
            }


        }
    }

    void Start()
    {
    }

}
