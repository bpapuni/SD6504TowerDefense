using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public static Status instance;
    WaveSpawner waveSpawner;
    [Header("Starting Gold")]
    public int gold;

    [Header("Unity Fields")]
    public int BallistaCost;
    public int FrostCost;
    public int TinyCost;

    private Text GoldAmount;
    private Text SpawnTime;

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
        GoldAmount = GameObject.FindGameObjectsWithTag("StatusText")[0].GetComponent<Text>();
        SpawnTime = GameObject.FindGameObjectsWithTag("StatusText")[1].GetComponent<Text>();
        UpdateGold();
    }

    private void Update()
    {
        if (waveSpawner.waveCountdown > 0)
            SpawnTime.text = "Time Until First Wave: " + Mathf.Round(waveSpawner.waveCountdown).ToString();
        else
            Destroy(SpawnTime);
    }

    public void UpdateGold()
    {
        GoldAmount.text = gold.ToString();
    }
}
