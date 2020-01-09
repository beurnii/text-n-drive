using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

//[System.Serializable] public class KeyPress : UnityEvent<string> { }

public class KeyPressAction : MonoBehaviour
{
    public static System.Action<string> keyPress;
    //public static KeyPress keyPress;
    public string keyValue = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeyPress()
    {
        if (keyPress != null)
            keyPress.Invoke(keyValue);
    }
}
