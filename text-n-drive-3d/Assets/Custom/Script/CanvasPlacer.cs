using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPlacer : MonoBehaviour
{
    public float distanceFromCamera = 0.4f;
    public float screenHight = 0.95f;
    // Start is called before the first frame update
    void Start()
    {
        Camera camera = Camera.main;
        var forward = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.0f, distanceFromCamera)) - camera.transform.position;
        var pointer = Quaternion.AngleAxis(-45.0f, Vector3.left) * forward;
        transform.position = pointer + camera.transform.position;

        var frustumHeight = 2.0f * distanceFromCamera * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        var frustumWidth = frustumHeight * camera.aspect;
        RectTransform rt = GetComponent<RectTransform>();
        transform.localScale = new Vector3(frustumWidth / rt.sizeDelta.x , frustumHeight * screenHight / rt.sizeDelta.y, 0);
        var ratio = transform.localScale.y / transform.localScale.x;
    }
}
