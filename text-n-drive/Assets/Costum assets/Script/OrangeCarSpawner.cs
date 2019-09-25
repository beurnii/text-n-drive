using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeCarSpawner : MonoBehaviour
{
    public GameObject OrangeCar;

    float generatingTiming = 1f;
    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        time += Time.deltaTime;
        if (time >= generatingTiming)
        {
            Random.seed = System.DateTime.Now.Millisecond;
            generatingTiming = Random.Range(4f, 6f);
            time = 0f;
            GameObject newCar = Instantiate(OrangeCar, transform);
        }
    }
}
