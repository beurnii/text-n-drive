using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject RestartButton;
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
        ObstacleCarLineChange.gameOverEvent += GameOverEventHandler;
    }


    void OnDisable()
    {
        ObstacleCarLineChange.gameOverEvent -= GameOverEventHandler;
    }

    void GameOverEventHandler()
    {
        GameOverScreen.SetActive(true);
        RestartButton.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
