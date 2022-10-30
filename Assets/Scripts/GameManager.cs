using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject playBtn;
    public GameObject pauseBtn;
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
        
        Time.timeScale = 0f;
        playBtn.SetActive(true);
        pauseBtn.SetActive(false);


    }

    public void PlayGame()
    {
        
        Time.timeScale = 1f;
        playBtn.SetActive(false);
        pauseBtn.SetActive(true);

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
