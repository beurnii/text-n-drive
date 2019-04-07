using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeCarScaling : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yPos = transform.position.y;
        float scaling;
        if (yPos < 0)
        {
            scaling = -0.4244f * yPos * yPos - 0.8200f * yPos + 1;
        }
        else
        {
            scaling = -0.4906f * yPos + 1;
        }
        transform.localScale = new Vector3(scaling, scaling, 1);
    }
}
