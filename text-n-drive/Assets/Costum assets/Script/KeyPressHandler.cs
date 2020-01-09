using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPressHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnEnable()
    {
        //KeyPressAction.keyPress.AddListener((str) => toto(str));

        //KeyPressAction.keyPress += KeyPressEventHandler;
    }


    void OnDisable()
    {
        //KeyPressAction.keyPress -= KeyPressEventHandler;
    }

    
}
