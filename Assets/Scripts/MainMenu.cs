using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public void ContinueGame()
    {
        if (PlayerPrefs.GetInt("Level Completed") > 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(PlayerPrefs.GetInt("Level Completed"));
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
		
}
