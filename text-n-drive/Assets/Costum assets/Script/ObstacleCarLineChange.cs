using UnityEngine;
using UnityEngine.Events;

public class ObstacleCarLineChange : MonoBehaviour
{
    public int lineNumber;
    public int CamPos { get; set; } = 1;
    public static System.Action gameOverEvent;
    public float timeToChangeLine = 0.5f;
    float arrivingTime;
    float endPos = 0;
    float startPos = 0;
    float currentPos = 0;

    public float cam0Line0_A = -0.0924f;
    public float cam0Line0_B = 0.1741f;
                         
    public float cam1Line0_A = 1.9594f;
    public float cam1Line0_B = -3.9708f;
                         
    public float cam2Line0_A = 4.2f;
    public float cam2Line0_B = -8.4f;


    public float cam0Line1_A = -2.185f;
    public float cam0Line1_B = 4.3951f;
                         
    public float cam1Line1_A = -0.025f;
    public float cam1Line1_B = 0.0635f;
                         
    public float cam2Line1_A = 1.884f;
    public float cam2Line1_B = -3.78f;


    public float cam0Line2_A = -4.4f;
    public float cam0Line2_B = 8.9f;
                         
    public float cam1Line2_A = -2.08f;
    public float cam1Line2_B = 4.2025f;
                         
    public float cam2Line2_A = -0.1411f;
    public float cam2Line2_B = 0.3156f;

    int lastCamPos = 0;

    public float higherColider = -3.7f;
    public float lowerColider = 0f;
    public float selfDestructSideLineHeigth = -1f;
    // Start is called before the first frame update
    void Start()
    {
        Random.seed = System.DateTime.Now.Millisecond;
        lineNumber = Random.Range(0, 3);
    }


    // Update is called once per frame
    void Update()
    {
        UpdateHorizontalPosition();
        CheckForColision();
        CheckForSelfDestruct();
    }

    void CheckForSelfDestruct()
    {
        if (transform.position.y < selfDestructSideLineHeigth && CamPos != lineNumber)
        {
            Destroy(gameObject);
        }
    }

    void CheckForColision()
    {
        if(transform.position.y < higherColider && CamPos == lineNumber)
        {
            Debug.Log("GAMEOVER");
            Destroy(gameObject);
            if (gameOverEvent != null)
                gameOverEvent.Invoke();
        }
    }

    void OnEnable()
    {
        CameraMovementSideToSide.updateCamPosEvent += UpdateCamPosition;
    }


    void OnDisable()
    {
        CameraMovementSideToSide.updateCamPosEvent -= UpdateCamPosition;
    }

    public void UpdateCamPosition(int pos)
    {
        lastCamPos = CamPos;
        CamPos = pos;
        SetupDeplacement();
    }

    void UpdateHorizontalPosition()
    {
        if (startPos != endPos)
        {
            startPos = CalculatePos(lastCamPos);
            endPos = CalculatePos(CamPos);
            deplacement();
        } else
        {
            transform.position = new Vector3(CalculatePos(CamPos), transform.position.y, transform.position.z);
        }

    }

    void SetupDeplacement()
    {
        endPos = CalculatePos(CamPos);
        startPos = CalculatePos(lastCamPos);
        arrivingTime = Time.time + timeToChangeLine;
    }

    void deplacement()
    {
        currentPos = Mathf.Lerp(startPos, endPos, 1 - (arrivingTime - Time.time) / timeToChangeLine);
        transform.position = new Vector3(currentPos, transform.position.y, transform.position.z);
    }

    float CalculatePos(int relativeCamPos)
    {
        float yPos = transform.position.y;
        float xPos = 0;
        switch (lineNumber)
        {
            case 0:
                if (relativeCamPos == 0) xPos = cam0Line0_A * yPos + cam0Line0_B;
                else if (relativeCamPos == 1) xPos = cam1Line0_A * yPos + cam1Line0_B;
                else if (relativeCamPos == 2) xPos = cam2Line0_A * yPos + cam2Line0_B;

                break;
            case 1:

                if (relativeCamPos == 0) xPos = cam0Line1_A * yPos + cam0Line1_B;
                else if (relativeCamPos == 1) xPos = cam1Line1_A * yPos + cam1Line1_B;
                else if (relativeCamPos == 2) xPos = cam2Line1_A * yPos + cam2Line1_B;

                break;
            case 2:
                if (relativeCamPos == 0) xPos = cam0Line2_A * yPos + cam0Line2_B;
                else if (relativeCamPos == 1) xPos = cam1Line2_A * yPos + cam1Line2_B;
                else if (relativeCamPos == 2) xPos = cam2Line2_A * yPos + cam2Line2_B;

                break;
            default: break;
        }

        return xPos;
    }
}
