using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UIElementPlacer : MonoBehaviour
{
    public GameObject UIElement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 messagePos = Camera.main.WorldToScreenPoint(this.transform.position);
        UIElement.transform.position = messagePos;
    }
}
