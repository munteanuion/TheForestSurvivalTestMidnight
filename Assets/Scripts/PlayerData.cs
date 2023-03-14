using UnityEngine;
public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    private int winCount = 0;
    private int loseCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Win()
    {
        winCount++;
    }

    public void Lose()
    {
        loseCount++;
        ManagerUI.Instance.ShowGameOver();
    }
    public int GetWin()
    {
        return winCount;
    }

    public int GetLose()
    {
        return loseCount;
    }

    private void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("WinCount", winCount);
        PlayerPrefs.SetInt("LoseCount", loseCount);
    }

    public void LoadData()
    {
        winCount = PlayerPrefs.GetInt("WinCount", 0);
        loseCount = PlayerPrefs.GetInt("LoseCount", 0);
    }
}
