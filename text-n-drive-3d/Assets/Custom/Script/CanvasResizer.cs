using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasResizer : MonoBehaviour
{
    public Camera _mainCamera;
    public float _scaleFactor = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        float distance = Vector3.Distance(transform.position, _mainCamera.transform.position);
        var frustumHeight = 2.0f * distance * Mathf.Tan(_mainCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        var frustumWidth = frustumHeight * _mainCamera.aspect;

        Debug.Log(frustumWidth);
    }

    // Update is called once per frame
    void Update()
    {
        //Scale();

    }
    private void Scale()
    {
        if (_mainCamera)
        {
            float camHeight;
            if (_mainCamera.orthographic)
            {
                camHeight = _mainCamera.orthographicSize * 2;
            }
            else
            {
                float distanceToCamera = Vector3.Distance(_mainCamera.transform.position, transform.position);
                camHeight = 2.0f * distanceToCamera * Mathf.Tan(Mathf.Deg2Rad * (_mainCamera.fieldOfView * 0.5f));
            }
            float scale = camHeight * _scaleFactor;

            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
