using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MessageReceiver : MonoBehaviour
{

    public GameObject messageSent;
    public GameObject messageReceived;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void messageSentHandler(string msg) {
        GameObject obj = Instantiate(messageSent, transform);
        obj.SendMessage("SetText", msg);

    }

    public void messageReceivedHandler(string msg)
    {
        GameObject obj = Instantiate(messageReceived, transform);
        obj.SendMessage("SetText", msg);
    }
}
