using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShiftKey : MonoBehaviour
{
    private bool isPressed;
    public static System.Action<bool> shiftPress;
    public Sprite spriteLight;
    public Sprite spriteDark;
    private Image image;

    void Start() {
        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(KeyPress);

        image = GetComponent<Image>();
        image.sprite = spriteLight;
    }

    void OnEnable() {
        LetterKey.keyPress += letterEventHandler;
        BackspaceButton.keyPress += keyHandler;
        SpaceKey.keyPress += letterEventHandler;
    }

    void OnDisable() {
        LetterKey.keyPress -= letterEventHandler;
        BackspaceButton.keyPress -= keyHandler;
        SpaceKey.keyPress -= letterEventHandler;
    }

    void letterEventHandler(string c ) {
        keyHandler();
    }

    void keyHandler() {
        isPressed = false;
        image.sprite = spriteLight;
        if (shiftPress != null)
            shiftPress.Invoke(false);
    }

    void KeyPress() {
        if (isPressed) {
            keyHandler();
            return;
        }
        isPressed = true;
        image.sprite = spriteDark;
        if (shiftPress != null)
            shiftPress.Invoke(true);
    }
}
