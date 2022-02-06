using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneController : MonoBehaviour
{
    float horizontalOffset;
    float desiredOffset;
    float startingOffset;
    float arrivingTime;
    public int currentLane = 1;
    float[] lanes;
    public float lineChangeTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        RoadData roadData = GameObject.Find("Road1").gameObject.GetComponent<RoadData>();
        lanes = roadData.lanes;

        switch (currentLane)
        {
            case 0:
                horizontalOffset = lanes[0];
                break;
            case 1:
                horizontalOffset = lanes[1];
                break;
            case 2:
                horizontalOffset = lanes[2];
                break;
        }
        desiredOffset = horizontalOffset;
    }

    public float GetOffset()
    {
        if (desiredOffset != horizontalOffset)
            horizontalOffset = Mathf.Lerp(startingOffset, desiredOffset, 1 - (arrivingTime - Time.time) / lineChangeTime);
        return horizontalOffset;
    }

    private void OnEnable()
    {
        SwipeHandler.OnSwipeRight += swipeRightHandler;
        SwipeHandler.OnSwipeLeft += swipeLeftHandler;
    }

    private void OnDisable()
    {
        SwipeHandler.OnSwipeRight -= swipeRightHandler;
        SwipeHandler.OnSwipeLeft -= swipeLeftHandler;
    }

    void swipeRightHandler()
    {
        if (horizontalOffset != desiredOffset)
            return;
        startingOffset = horizontalOffset;
        arrivingTime = Time.time + lineChangeTime;
        currentLane = Math.Max(currentLane - 1, 0);
        desiredOffset = lanes[currentLane];
    }

    void swipeLeftHandler()
    {
        if (horizontalOffset != desiredOffset)
            return;
        startingOffset = horizontalOffset;
        arrivingTime = Time.time + lineChangeTime;
        currentLane = Math.Min(currentLane + 1, 2);
        desiredOffset = lanes[currentLane];
    }
}
