using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UIResizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Resize();
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
            Resize();
        #endif
    }

    void Resize()
    {
        float posy = this.transform.position.y;
        RectTransform rt = this.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(0, posy * 2);
    }


}
