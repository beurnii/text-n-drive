using Lean.Touch;
using RoadArchitect;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoadFollower : MonoBehaviour
{
    public Road road;
    public float speed = 10f;
    public float startPosition = 0;
    public float endPosition = 1;
    private float distance;
    SplineC spline;
    public float verticalOffset = 1;


    float horizontalOffset;
    float desiredOffset;
    float startingOffset;
    public float position = 0f;
    public bool reverse = false;

    public float leftLane = 1.5f;
    public float centerLane = 4.25f;
    public float rightLane = 7.5f;

    public int currentLane = 1;
    public float lineChangeTime = 0.5f;

    float arrivingTime;

    public bool playersCar = false;

    // Start is called before the first frame update
    void Start()
    {
        spline = road.transform.Find("Spline").gameObject.GetComponent<SplineC>();
        distance = endPosition - startPosition;
        switch (currentLane)
        {
            case 0:
                horizontalOffset = leftLane;
                break;
            case 1:
                horizontalOffset = centerLane;
                break;
            case 2:
                horizontalOffset = rightLane;
                break;
        }
        desiredOffset = horizontalOffset;
    }

    private void OnEnable()
    {
        if (playersCar)
        {
            SwipeHandler.OnSwipeRight += swipeRightHandler;
            SwipeHandler.OnSwipeLeft += swipeLeftHandler;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (desiredOffset != horizontalOffset)
            horizontalOffset = Mathf.Lerp(startingOffset, desiredOffset, 1 - (arrivingTime - Time.time) / lineChangeTime);
        
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
    }

    void swipeRightHandler()
    {
        if (horizontalOffset != desiredOffset)
            return;

        startingOffset = horizontalOffset;
        arrivingTime = Time.time + lineChangeTime;
        switch (currentLane)
        {
            case 1: desiredOffset = leftLane; currentLane = 0; break;
            case 2: desiredOffset = centerLane; currentLane = 1; break;
        }
    }

    void swipeLeftHandler()
    {
        if (horizontalOffset != desiredOffset)
            return;

        startingOffset = horizontalOffset;
        arrivingTime = Time.time + lineChangeTime;
        switch (currentLane)
        {
            case 0: desiredOffset = centerLane; currentLane = 1; break;
            case 1: desiredOffset = rightLane; currentLane = 2; break;
        }
    }
}
