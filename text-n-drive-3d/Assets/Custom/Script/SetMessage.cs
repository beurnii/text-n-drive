using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMessage : MonoBehaviour
{
    Text text;
    string message = "";
    bool showCursor = false;
    float time = 0;
    public float cursorTimer = 0.6f;
    string cursor = "<color=#808080>|</color>";

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = message;
    }

    void OnEnable()
    {
        LetterKey.keyPress += KeyPressEventHandler;
        BackspaceButton.keyPress += BackspaceEventHandler;
        SpaceKey.keyPress += KeyPressEventHandler;
    }

    void OnDisable()
    {
        LetterKey.keyPress -= KeyPressEventHandler;
        BackspaceButton.keyPress -= BackspaceEventHandler;
        SpaceKey.keyPress -= KeyPressEventHandler;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > cursorTimer)
            ToggleCursor();
    }

    public void KeyPressEventHandler(string c) {
        if (showCursor) {
            message = message.Remove(message.Length - cursor.Length, cursor.Length);
            message += c;
            message += cursor;
        } else
            message += c;
        text.text = message;
    }

    void BackspaceEventHandler() {
        if (message.Length == 0)
            return;
        message = message.Remove(message.Length - (showCursor? cursor.Length+1 : 1), 1);
        text.text = message;
    }

    void ToggleCursor() {
        time -= cursorTimer;
        if (showCursor) {
            showCursor = false;
            message = message.Remove(message.Length - cursor.Length, cursor.Length);
            text.text = message;
        } else {
            message += cursor;
            text.text = message;
            showCursor = true;
        }
    }
}
