using UnityEngine;
using UnityEngine.UI;

public class LetterKey : MonoBehaviour
{
    public static System.Action<string> keyPress;
    Text text;

    void Start()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(KeyPress);

        text = GetComponentInChildren<Text>();
    }

    private void OnEnable() {
        ShiftKey.shiftPress += shiftKeyHandler;
    }

    private void OnDisable() {
        ShiftKey.shiftPress -= shiftKeyHandler;
    }

    void shiftKeyHandler(bool isDown) {
        if (isDown)
            text.text = text.text.ToUpper();
        else
            text.text = text.text.ToLower();
    }

    public void KeyPress() {
        if (keyPress != null)
            keyPress.Invoke(text.text);
    }
}
