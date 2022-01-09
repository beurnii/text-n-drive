using RoadArchitect;
using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class bench : MonoBehaviour
{
    public GameObject spline;
    public PathCreator path;
    public bool createPath = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.transform.forward);
    }

    void listChildren()
    {
        if (!createPath)
            return;

        Debug.Log("Generating");
        foreach (Transform node in spline.transform)
        {
            path.bezierPath.AddSegmentToEnd(node.localPosition);
            //Debug.Log(node.localPosition.x);
            //Debug.Log(node.transform.position.x);
        }

        createPath = false;

    }
}
