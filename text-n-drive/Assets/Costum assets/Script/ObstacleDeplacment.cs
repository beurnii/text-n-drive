using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDeplacment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speedDown = 1;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1,0,0) * speedDown * Time.deltaTime);
    }
}
