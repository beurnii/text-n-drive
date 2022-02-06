using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUpAndDown : MonoBehaviour
{

    public float positionUp = 1f;
    public float positionDown = 0f;

    public float transitionTime = 0.5f;
    bool currentPositionIsDown;
    float arrivingTime;
    float endPos = 0;
    float startPos = 0;
    float currentPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = positionUp;
        currentPositionIsDown = false;
       // transform.localPosition = new Vector3(transform.localPosition.x, currentPos, transform.localPosition.z);
    }

    private void OnEnable()
    {
        SwipeHandler.OnSwipeUp += OnSwipeUpHandler;
        SwipeHandler.OnSwipeDown += OnSwipeDownHandler;

    }

    private void OnDisable()
    {
        SwipeHandler.OnSwipeUp -= OnSwipeUpHandler;
        SwipeHandler.OnSwipeDown -= OnSwipeDownHandler;
    }

    void Update()
    {
        if (endPos != startPos)
        {
            deplacement();
        }
    }

    public void OnSwipeUpHandler()
    {
        if (!currentPositionIsDown)
        {
            currentPositionIsDown = true;
            endPos = positionDown;
            startPos = currentPos;
            arrivingTime = Time.time + transitionTime;
        }
    }

    public void OnSwipeDownHandler()
    {
        if (currentPositionIsDown)
        {
            currentPositionIsDown = false;
            endPos = positionUp;
            startPos = currentPos;
            arrivingTime = Time.time + transitionTime;
        }
    }


    void deplacement()
    {
        currentPos = Mathf.Lerp(startPos, endPos, 1 - (arrivingTime - Time.time) / transitionTime);
        //transform.localPosition = new Vector3(transform.localPosition.x, currentPos, transform.localPosition.z);
        transform.localEulerAngles = new Vector3(currentPos, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}