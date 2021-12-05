using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    public float notificationTimer = 3;
    public GameObject notification;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableNotification()
    {
        notification.SetActive(true);

        StartCoroutine(DisableNotification());
    }

    IEnumerator DisableNotification()
    {

        yield return new WaitForSeconds(notificationTimer);

        notification.SetActive(false);
    }

}
