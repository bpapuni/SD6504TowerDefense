using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public static Status instance;
    WaveSpawner waveSpawner;
    [Header("Starting Gold")]
    public int gold;
    public int lives;

    private Text GoldAmount;
    private Text StatusMessage;
    private Text LivesAmount;
    private Image Play;
    private Image Pause;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than 1");
            return;
        }

        instance = this;
    }

    void Start()
    {
        waveSpawner = WaveSpawner.instance;
        GoldAmount = GameObject.FindGameObjectWithTag("GoldText").GetComponent<Text>();
        StatusMessage = GameObject.FindGameObjectWithTag("StatusText").GetComponent<Text>();
        LivesAmount = GameObject.FindGameObjectWithTag("LivesText").GetComponent<Text>();
        Play = GameObject.FindGameObjectsWithTag("PlayPause")[0].GetComponent<Image>();
        Pause = GameObject.FindGameObjectsWithTag("PlayPause")[1].GetComponent<Image>();
        Play.gameObject.SetActive(false);
        UpdateGold(0);
        UpdateLives(0);
        InvokeRepeating("WaveSpawnTime", 0f, 0.5f);


    }

    void WaveSpawnTime()
    {
        if (waveSpawner.waveCountdown > 0)
            StatusMessage.text = "Time Until First Wave: " + Mathf.Round(waveSpawner.waveCountdown).ToString();
        else
        {
            StatusMessage.text = "";
            CancelInvoke("WaveSpawnTime");
        }
    }

    public void UpdateGold(int goldChange)
    {
        gold += goldChange;
        GoldAmount.text = gold.ToString();
    }


    public void UpdateLives(int livesChange)
    {
        lives -= livesChange;
        LivesAmount.text = lives.ToString();
        if (lives <= 0)
        {
            GameManager.EndGame();
        }
    }

    public void ShowMessage(string message)
    {
        StatusMessage.text = message;
    }

    public void ShowMessage(string message, int displayTime)
    {
        StartCoroutine(Display(message, displayTime));
    }

    public void ClearMessage()
    {
        StatusMessage.text = "";
    }

    IEnumerator Display(string message, int displayTime)
    {
        StatusMessage.text = message;
        yield return new WaitForSeconds(displayTime);
        StatusMessage.text = "";
    }

    public void TogglePlayPause(bool paused)
    {
        if (paused)
        {
            ShowMessage("Game Paused");
            Play.gameObject.SetActive(true);
            Pause.gameObject.SetActive(false);
        }
        else
        {
            ShowMessage("Game Resumed", 3);
            Play.gameObject.SetActive(false);
            Pause.gameObject.SetActive(true);
        }
    }
}
