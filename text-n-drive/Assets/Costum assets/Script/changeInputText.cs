using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class changeInputText : MonoBehaviour
{
    public GameObject textObject;
    private TMP_Text textComponent;
    private int compteur = 0;
    public string baseStr = "cheval";
    private string[] strArray;
 

    // Start is called before the first frame update
    void Start(){
        textComponent = textObject.GetComponent<TMP_Text>();
        textComponent.text = baseStr;
        strArray = new string[baseStr.Length];
        for( int i = 0; i < baseStr.Length; i++){
            strArray[i] = "<color=black>"+baseStr[i]+"</color>";
        }
        newDisplayStr();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void newDisplayStr()
    {
        string str = "";
        foreach(string s in strArray)
        {
            str += s;
        }

        textComponent.text = str;

    }

    public void updatetext(string c) {
        if (compteur >= baseStr.Length) return;
        if (baseStr[compteur] == c[0])
        {
            strArray[compteur] = "<color=green>" + baseStr[compteur] + "</color>";
        }
        else
        {
            strArray[compteur] = "<color=red>" + baseStr[compteur] + "</color>";
        }
        compteur++;
        newDisplayStr();
    }
}
