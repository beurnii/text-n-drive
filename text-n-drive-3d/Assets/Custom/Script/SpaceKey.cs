using UnityEngine;
using UnityEngine.UI;

public class SpaceKey : MonoBehaviour {
    public static System.Action<string> keyPress;

    void Start() {
        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(KeyPress);
    }

    public void KeyPress() {
        if (keyPress != null)
            keyPress.Invoke(" ");
    }
}
