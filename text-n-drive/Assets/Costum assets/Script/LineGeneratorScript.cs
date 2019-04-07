using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGeneratorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public float generatingTiming = 1f;
    private float time = 0f;
    public GameObject line;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= generatingTiming)
        {

            time = 0f;
            Instantiate(line, transform);
        }
    }
}
