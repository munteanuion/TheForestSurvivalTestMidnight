using TMPro;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    public static ManagerUI Instance;

    [SerializeField] private TextMeshProUGUI _loseCountTextGameOver;
    [SerializeField] private GameObject _gameOverScreen;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowGameOver()
    {
        _loseCountTextGameOver.text = "Lose Count: " + PlayerData.Instance.GetLose() ;
        _gameOverScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
