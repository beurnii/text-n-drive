using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageStackSizer : MonoBehaviour
{
    float maxHeight;
    VerticalLayoutGroup vlg;
    // Start is called before the first frame update
    void Start()
    {
        maxHeight = gameObject.GetComponent<RectTransform>().sizeDelta.y;
        vlg = gameObject.GetComponent<VerticalLayoutGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vlg.preferredHeight > maxHeight)
        {
            Destroy(gameObject.transform.GetChild(0).gameObject);
        }
    }
}
