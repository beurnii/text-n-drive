using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private Text textComponent;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        textComponent = this.GetComponent<Text>();
        textComponent.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void IncreaseScore()
    {
        score++;
        textComponent.text = score.ToString();
    }
}
