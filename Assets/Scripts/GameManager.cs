using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    //[SerializeField]private float startTime;
    [SerializeField] private Text currentTime;
    [SerializeField] private Text bestScore;
    [SerializeField] private Text completedLevel;
    [SerializeField] private Text score;

    public int currentLevel;
    public bool completed = false;

    private float currentScore;
    private float highScore;
    //private ShowWinScreen win;
    /*public Rect topScore;
    public Rect timerRect;
    public int winScreenWidth, winScreenHeight;
    public GUISkin skin;
    private bool showWinScreen = false;*/

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

    /*void CountDown()
    {
        startTime -= Time.deltaTime;
        currentScore = startTime;
        currentTime = string.Format("{0:0.00}", startTime);
        if (startTime <= 0)
        {
            startTime = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene(8);
        }
    }

    public void CompleteLevel()
    {
        showWinScreen = true;
        completed = true;
    }*/

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
        //win.SetActive();
        completedLevel.text = "Completed Level: " + currentLevel.ToString();
        score.text = string.Format("Score: {0:0.00}", currentScore);
    }

    /*
    void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(topScore, bestScore, skin.GetStyle("timer"));
        GUI.Label(timerRect, currentTime, skin.GetStyle("timer"));

        if (showWinScreen)
        {
            Rect winScreenRect = new Rect((Screen.width / 2) - (winScreenWidth/2), (Screen.height / 2) - (winScreenHeight /2), winScreenWidth, winScreenHeight);
            GUI.Box(winScreenRect, "Level Win");

            currentScore = startTime;
            if (GUI.Button(new Rect(winScreenRect.x + winScreenRect.width - 170, winScreenRect.y + winScreenHeight - 60, 150, 40), "Continue"))
            {
                LoadNextLevel();
            }
            if (GUI.Button(new Rect(winScreenRect.x + 20, winScreenRect.y + winScreenHeight - 60, 100, 40), "Quit"))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("main menu");
            }

            GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 40, 300, 50), "Completed Level: " + currentLevel.ToString(), skin.GetStyle("timer"));
            GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 100, 300, 50), string.Format("Score: {0:0.00}", currentScore), skin.GetStyle("timer"));
        }
    }*/
}
