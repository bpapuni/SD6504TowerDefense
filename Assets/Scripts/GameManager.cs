using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private bool paused = false;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (paused)
                PlayGame();
            else
                PauseGame();
        }
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        paused = true;
        Time.timeScale = 0f;


    }

    public void PlayGame()
    {
        paused = false;
        Time.timeScale = 1f;

    }

    public static void EndGame()
    {

        Time.timeScale = 0f;
        SceneManager.LoadScene("EndGame");

    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
