using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class MyStringEvent : UnityEvent<string>{}

public class MessageManager : MonoBehaviour
{
    public MyStringEvent newSentMessageEvent;
    public MyStringEvent newReceivedMessageEvent;

    public MyStringEvent newMessageToTypeEvent;

    private int messageCounter = 0;
    private List<string> messages = new List<string> { "R_whats up", "S_the roof you", "S_nice talk", "R_see you later" };
    private bool readyForNextMessage = true;
    string currentMessage;

    // Start is called before the first frame update
    void Start()
    {
        if (newSentMessageEvent == null)
            newSentMessageEvent = new MyStringEvent();

    }

    // Update is called once per frame
    void Update()
    {
        if (messageCounter < messages.Count && readyForNextMessage)
        {
            nextMessageProcess();
        }
    }

    private void nextMessageProcess()
    {
        readyForNextMessage = false;

        string[] args = messages[messageCounter].Split('_');
        string owner = args[0];
        currentMessage = args[1];

        if (owner == "S")
        {
            StartCoroutine(SendingMessageDelay());
        }
        else
        {
            StartCoroutine(receivingMessageDelay());
        }
    }

    IEnumerator SendingMessageDelay()
    {

        yield return new WaitForSeconds(1);
        newMessageToTypeEvent.Invoke(currentMessage);
    }

    IEnumerator receivingMessageDelay()
    {
        int delay = (int)Random.Range(1.0f, 5.0f);
        yield return new WaitForSeconds(delay);
        receiving_message(currentMessage);
        messageCounter++;
        readyForNextMessage = true;
    }

    public void messageCompletHandler()
    {
        sending_message(currentMessage);
        messageCounter++;
        readyForNextMessage = true;

    }

    private void sending_message(string msg)
    {
        newSentMessageEvent.Invoke(msg);
    }

    private void receiving_message(string msg)
    {
        newReceivedMessageEvent.Invoke(msg);
    }
}
