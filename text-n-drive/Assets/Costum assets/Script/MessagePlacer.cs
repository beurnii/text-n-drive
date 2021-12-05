using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePlacer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string msg)
    {
        GameObject msgChild = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        msgChild.GetComponent<UnityEngine.UI.Text>().text = msg;
    }
}
