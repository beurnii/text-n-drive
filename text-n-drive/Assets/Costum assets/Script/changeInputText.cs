using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class changeInputText : MonoBehaviour
{
    public GameObject textObject;
    private Text textComponent;
    private int counter = 0;
    public string baseStr = "test text";
    private string[] strArray;
    [Header("Events")]
    public UnityEvent messageCompleteEvent;
    private bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        textComponent = textObject.GetComponent<Text>();
        Begin();
    }

    private void Begin()
    {
        textComponent.text = baseStr;
        strArray = new string[baseStr.Length];
        for (int i = 0; i < baseStr.Length; i++)
        {
            strArray[i] = "<color=black>" + baseStr[i] + "</color>";
        }
        newDisplayStr();
    }

    void OnEnable()
    {
        KeyPressAction.keyPress += KeyPressEventHandler;
        ObstacleCarLineChange.gameOverEvent += GameOverEventHandler;
    }

    void OnDisable()
    {
        KeyPressAction.keyPress -= KeyPressEventHandler;
        ObstacleCarLineChange.gameOverEvent -= GameOverEventHandler;
    }

    private void newDisplayStr()
    {
        string str = "";
        foreach (string s in strArray)
        {
            str += s;
        }

        textComponent.text = str;
        if (baseStr.Length == counter)
        {
            if (messageCompleteEvent != null)
                messageCompleteEvent.Invoke();
            Restart();
        }
    }

    public void KeyPressEventHandler(string c)
    {
        if (!gameOver)
        {
            if (counter >= baseStr.Length) return;
            if (baseStr[counter] == c[0])
            {
                strArray[counter] = "<color=green>" + baseStr[counter] + "</color>";
                counter++;
            } else
            {
                if (baseStr[counter] == ' ')
                    strArray[counter] = "<color=red>" + "_" + "</color>";
                else
                    strArray[counter] = "<color=red>" + baseStr[counter] + "</color>";
            }
            newDisplayStr();
        }
    }

    private void Restart()
    {
        counter = 0;
        Begin();
    }

    void GameOverEventHandler()
    {
        gameOver = true;
    }
}
