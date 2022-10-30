using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPause : MonoBehaviour
{
    public GameObject playBtn;
    public GameObject pauseBtn;

    public void PauseGame()
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0f;
        playBtn.SetActive(true);
        pauseBtn.SetActive(false);


    }

    public void PlayGame()
    {
        Debug.Log("Game Play");
        Time.timeScale = 1f;
        playBtn.SetActive(false);
        pauseBtn.SetActive(true);

    }
}
