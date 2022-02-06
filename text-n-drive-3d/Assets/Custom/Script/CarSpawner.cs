using RoadArchitect;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carsPrefab;
    public int numberOfCars = 100;

    // Start is called before the first frame update
    void Start()
    {
        carsPrefab = Resources.LoadAll<GameObject>("CarsPrefabs");
        for (int i = 0; i < numberOfCars; i++)
        {
            GameObject prefab = carsPrefab[Random.Range(0, carsPrefab.Length)];
            Instantiate(prefab, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
