using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUpAndDown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        currentPos = startPos;
        currentPositionIsDown = false;
        transform.position = new Vector3(transform.position.x, startPos, transform.position.z);

    }

    public float positionUp = 0f;
    public float positionDown = -7f;

    public float transitionTime = 0.8f;
    bool currentPositionIsDown;
    float arrivingTime;
    float endPos = 0;
    float startPos = 0;
    float currentPos = 0;

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
        transform.position = new Vector3(transform.position.x, currentPos, transform.position.z);
    }
}