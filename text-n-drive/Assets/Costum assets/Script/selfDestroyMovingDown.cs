using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestroyMovingDown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float heigth = -10;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < heigth)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
