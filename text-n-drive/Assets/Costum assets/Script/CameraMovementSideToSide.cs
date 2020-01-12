using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraMovementSideToSide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = timeScaler;
        currentPos = positionCenter;
        transform.position = new Vector3(currentPos, transform.position.y, transform.position.z);
        if (updateCamPosEvent != null) updateCamPosEvent.Invoke(linePos);
    }

    public float positionLeft = -0.035f;
    public float positionCenter = -0.002f;
    public float positionRight = 0.03f;
    public float timeScaler = 1f;

    public float timeToChangeLine = 0.5f;
    int linePos = 1;
    float arrivingTime;
    float endPos = 0;
    float startPos = 0;
    float currentPos = 0;

    //public BroadCastToObstacle ObstacleManager;
    public static System.Action<int> updateCamPosEvent;

    public int LinePos
    {
        get { return linePos; }
    }

    // Update is called once per frame
    void Update()
    {
        if (endPos != startPos)
        {
            deplacement();
        }
    }

    public void SwipeLeftHandler()
    {
        if (linePos == 2)
        {
        } else if (linePos == 1)
        {
            endPos = positionRight;
            startPos = currentPos;
            arrivingTime = Time.time + timeToChangeLine;
            linePos = 2;

            if (updateCamPosEvent != null) updateCamPosEvent.Invoke(linePos);

        } else
        {
            startPos = currentPos;
            endPos = positionCenter;
            arrivingTime = Time.time + timeToChangeLine;
            linePos = 1;

            if (updateCamPosEvent != null) updateCamPosEvent.Invoke(linePos);

        }
    }

    public void SwipeRightHandler()
    {
        if (linePos == 0)
        {
        } else if (linePos == 1)
        {
            endPos = positionLeft;
            startPos = currentPos;
            arrivingTime = Time.time + timeToChangeLine;
            linePos = 0;

            if (updateCamPosEvent != null) updateCamPosEvent.Invoke(linePos);

        } else
        {
            startPos = currentPos;
            endPos = positionCenter;
            arrivingTime = Time.time + timeToChangeLine;
            linePos = 1;

            if (updateCamPosEvent != null) updateCamPosEvent.Invoke(linePos);

        }
    }

    void deplacement()
    {
        currentPos = Mathf.Lerp(startPos, endPos, 1 - (arrivingTime - Time.time) / timeToChangeLine);
        transform.position = new Vector3(currentPos, transform.position.y, transform.position.z);
    }
}
