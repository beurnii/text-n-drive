using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class KeyPressAction : MonoBehaviour
{
    public static System.Action<string> keyPress;
    //public static KeyPress keyPress;
    public string keyValue = "";
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(KeyPress);
    }

    public void KeyPress()
    {
        if (keyPress != null)
            keyPress.Invoke(keyValue);
    }
}
