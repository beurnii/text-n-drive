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
    private string baseStr;
    private string[] strArray;
    [Header("Events")]
    public UnityEvent messageCompleteEvent;
    private bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        textComponent = textObject.GetComponent<Text>();
    }

    public void newMessageToTypeHandler(string msg)
    {
        counter = 0;
        baseStr = msg;
        strArray = new string[baseStr.Length];
        for (int i = 0; i < baseStr.Length; i++)
        {
            strArray[i] = "<color=black>" + msg[i] + "</color>";
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
            complete();
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

    void GameOverEventHandler()
    {
        gameOver = true;
    }

    void complete()
    {
        if (messageCompleteEvent != null)
            messageCompleteEvent.Invoke();
        textComponent.text = "";
    }
}
