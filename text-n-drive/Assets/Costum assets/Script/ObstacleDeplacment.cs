using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDeplacment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speedDown = 0.4f;
    public int maxHeigth = 2;
    public int minHeigth = -1;
        
    // Update is called once per frame
    // de 2 a -1
    //y=a(b^-1)+c
    void Update()
    {
        float yPos = transform.position.y;
        float speed = speedDown*(maxHeigth-yPos);
        transform.Translate(speed * Vector3.down * Time.deltaTime);
        float newZ = transform.position.y / 30;
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
    }
}
