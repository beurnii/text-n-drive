using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementSideToSide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = timeScaler;
        currentPos = positionCenter;
        transform.position = new Vector3(currentPos, transform.position.y, transform.position.z);
        ObstacleManager.UpdateChildrenPosition(lineNum);
    }
    public float positionLeft = -0.035f;
    public float positionCenter = -0.002f;
    public float positionRight = 0.03f;
    public float timeScaler = 1f;

    public float timeToChangeLine = 0.5f;
    int lineNum = 1;
    float arrivingTime;
    float endPos = 0;
    float startPos = 0;
    float currentPos = 0;

    public BroadCastToObstacle ObstacleManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow)){
            if (lineNum == 0)
            {
            }
            else if (lineNum == 1){
                endPos = positionLeft;
                startPos = currentPos;
                arrivingTime = Time.time + timeToChangeLine;
                lineNum = 0;

                ObstacleManager.UpdateChildrenPosition(lineNum);
                
            }
            else
            {
                startPos = currentPos;
                endPos = positionCenter;
                arrivingTime = Time.time + timeToChangeLine;
                lineNum = 1;

                ObstacleManager.UpdateChildrenPosition(lineNum);

            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (lineNum == 2)
            {
            }
            else if (lineNum == 1)
            {
                endPos = positionRight;
                startPos = currentPos;
                arrivingTime = Time.time + timeToChangeLine;
                lineNum = 2;

                ObstacleManager.UpdateChildrenPosition(lineNum);

            } else
            {
                startPos = currentPos;
                endPos = positionCenter;
                arrivingTime = Time.time + timeToChangeLine;
                lineNum = 1;

                ObstacleManager.UpdateChildrenPosition(lineNum);

            }
        }
        if (endPos != startPos)
        {
            deplacement();
        }

    }

    void deplacement()
    {
        currentPos = Mathf.Lerp(startPos, endPos, 1 - (arrivingTime - Time.time) / timeToChangeLine);
        transform.position = new Vector3(currentPos, transform.position.y, transform.position.z);
    }
}
