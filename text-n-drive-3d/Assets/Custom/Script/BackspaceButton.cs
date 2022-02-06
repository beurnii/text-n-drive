using UnityEngine;
using UnityEngine.UI;

public class BackspaceButton : MonoBehaviour
{
    public static System.Action keyPress;
    //public static KeyPress keyPress;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(KeyPress);
    }

    public void KeyPress()
    {
        if (keyPress != null)
            keyPress.Invoke();
    }
}
