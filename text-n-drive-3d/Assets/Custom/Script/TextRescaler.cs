using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRescaler : MonoBehaviour
{
    public GameObject ScalingParent;
    // Start is called before the first frame update
    void Start()
    {
        float ratio = ScalingParent.transform.localScale.y / ScalingParent.transform.localScale.x;
        transform.localScale = new Vector2(ratio, 1);
        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x / ratio, rt.sizeDelta.y);
    }
}
