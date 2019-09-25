using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class OrangeCarScaling : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Scale();
    }
    public float scalingMult = 0.8f;
    // Update is called once per frame
    void Update()
    {
        Scale();
    }

    void Scale()
    {
        float yPos = transform.position.y;
        float scaling;
        scaling = -0.4906f * yPos + 1;
        transform.localScale = new Vector3(scaling * scalingMult, scaling, 1);
    }
}
