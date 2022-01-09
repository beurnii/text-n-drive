using RoadArchitect;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadFollower : MonoBehaviour
{
    public Road road;
    public float speed = 0.1f;
    public float startPos = 0;
    public float endPos = 1;
    private float distance;
    SplineC spline;
    public float verticalOffset = 1;
    public float horizontalOffset = 0;
    public float pos = 0f;
    public bool reverse = false;
    // Start is called before the first frame update
    void Start()
    {
        spline = road.transform.Find("Spline").gameObject.GetComponent<SplineC>();
        distance = endPos - startPos;
    }

    void getEndPos()
    {
        endPos = spline.nodes[spline.GetNodeCount() - 1].time;
    }

    // Update is called once per frame
    void Update()
    {
        int direction = reverse ? -1 : 1;
        pos += speed * Time.deltaTime * direction;
        if (pos > endPos)
            pos -= distance;

        if (pos < startPos)
            pos += distance;

        Vector3 EditorCameraV1;
        Vector3 EditorCameraV2;
        spline.GetSplineValueBoth(pos, out EditorCameraV1, out EditorCameraV2);
        this.transform.rotation = Quaternion.LookRotation(EditorCameraV2 * direction);

        Vector3 horiMul = new Vector3(this.transform.forward.z, 0, -this.transform.forward.x);
        Vector3 offset = horiMul * horizontalOffset;

        this.transform.position = EditorCameraV1 + new Vector3(offset.x, verticalOffset, offset.z);

    }

}
