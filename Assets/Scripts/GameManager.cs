using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    [SerializeField] private Text currentTime;
    [SerializeField] private Text bestScore;
    [SerializeField] private Text completedLevel;
    [SerializeField] private Text score;

    public int currentLevel;
    public bool completed = false;

    private float currentScore;
    private float highScore;

    private bool ready = true;
    private bool start = false;

    void Start()
    {
        highScore = PlayerPrefs.GetFloat("Level " + currentLevel.ToString() + " score");
        bestScore.text = string.Format("High Score: {0:0.00}", highScore);
        if (PlayerPrefs.GetInt("Level Completed") > 1)
        {
            currentLevel = PlayerPrefs.GetInt("Level Completed");
        } else
        {
            currentLevel = 1;
        }
    }

    void Update()
    {
        GameStart();
    }

    void GameStart()
    {
        if (!completed)
        {
            if (!UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.Equals("Game Complete"))
            {
                if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && ready)
                {
                    TimeCounter();
                    ready = false;
                    start = true;
                }
                else if (start)
                {
                    TimeCounter();
                }
            }
        }
    }

    void TimeCounter()
    {
        currentScore += Time.deltaTime;
        currentTime.text = string.Format("{0:0.00}", currentScore);
    }

    public void LoadNextLevel()
    {
        if (!UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.Equals("Game Complete"))
        {
            HighScore();
            currentLevel += 1;
            SaveGame();
            UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel);
        }
        else
        {
            currentLevel = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel);
        }
    }

    void HighScore()
    {
        if (highScore > currentScore)
        {
            highScore = currentScore;
        }
        PlayerPrefs.SetFloat("Level " + currentLevel.ToString() + " score", highScore);
    }

    void SaveGame()
    {
        PlayerPrefs.SetInt("Level Completed", currentLevel);
    }

    public void ReturnMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void WinScreen()
    {
        completed = true;
        completedLevel.text = "Completed Level: " + currentLevel.ToString();
        score.text = string.Format("Score: {0:0.00}", currentScore);
    }
		
}
