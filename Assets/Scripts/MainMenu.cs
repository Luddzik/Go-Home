using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public void ContinueGame()
    {
        if (PlayerPrefs.GetInt("Level Completed") > 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(PlayerPrefs.GetInt("Level Complete"));
        }
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("Level Completed", 0);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    /*public GUISkin skin;

    void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(new Rect(Screen.width / 2 -115, Screen.height / 2 - 100, 300, 100), "Go Home");
        if (PlayerPrefs.GetInt("Level Completed") >0)
        {
            if (GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 , 100, 50), "Continue"))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(PlayerPrefs.GetInt("Level Completed"));
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 60, 100, 50), "New Game"))
            {
                PlayerPrefs.SetInt("Level Completed", 0);
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 120, 100, 50), "Quit"))
            {
                Application.Quit();
            }
        }
        else
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 50), "Play"))
            {
                PlayerPrefs.SetInt("Level Completed", 0);
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 60, 100, 50), "Quit"))
            {
                Application.Quit();
            }
        }
    }*/
}
