using Lean.Touch;
using RoadArchitect;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoadFollower : MonoBehaviour
{
    public float speed = 15f;
    float startPosition = 0;
    float endPosition = 1;
    float distance;
    SplineC spline;
    public float verticalOffset = 0.52f;
    float horizontalOffset;
    public float position = 0f;
    public bool reverse = false;
    public bool performanceMode = true;
    float[] lanes;
    LaneController laneController = null;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        spline = GameObject.Find("Spline").gameObject.GetComponent<SplineC>();

        RoadData roadData = GameObject.Find("Road1").gameObject.GetComponent<RoadData>();
        startPosition = roadData.startPosition;
        endPosition = roadData.endPosition;
        distance = endPosition - startPosition;

        lanes = roadData.lanes;

        laneController = GetComponent<LaneController>();
        if (laneController)
        {
            horizontalOffset = laneController.GetOffset();
            position = startPosition;
        }
        else
        {
            int currentLane = Random.Range(0, 3);
            horizontalOffset = lanes[currentLane];
            float padding = 0.01f;
            do {
                position = Random.Range(startPosition, endPosition);
            } while (currentLane == 1 
                     && startPosition + padding > position 
                     && position > endPosition - padding);
            reverse = Random.Range(0, 2) == 0;
            setPosition();
        }
        cam = GameObject.Find("PlayerCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (laneController)
            horizontalOffset = laneController.GetOffset();
        else {
            Vector3 screenPoint = cam.WorldToViewportPoint(transform.position);
            bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
            if (!onScreen && performanceMode)
                return;
        }
        
        setPosition();

    }

    void setPosition()
    {
        var oldpos = transform.position;
        int direction = reverse ? -1 : 1;
        position += speed / 1000 * Time.deltaTime * direction;
        if (position > endPosition)
            position -= distance;

        if (position < startPosition)
            position += distance;

        Vector3 EditorCameraV1;
        Vector3 EditorCameraV2;
        spline.GetSplineValueBoth(position, out EditorCameraV1, out EditorCameraV2);
        this.transform.rotation = Quaternion.LookRotation(EditorCameraV2 * direction);

        Vector3 horiMul = new Vector3(this.transform.forward.z, 0, -this.transform.forward.x);
        Vector3 offset = horiMul * horizontalOffset;

        this.transform.position = EditorCameraV1 + new Vector3(offset.x, verticalOffset, offset.z);
        var newpos = transform.position;

        float dist = Vector3.Distance(oldpos, newpos);
        //Debug.Log(dist / Time.deltaTime);
    }

}
