using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadCastToObstacle : MonoBehaviour
{
    public int camPos = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateChildrenPosition(int pos)
    {
        camPos = pos;
        this.BroadcastMessage("UpdateCamPosition", pos);
    }
}
