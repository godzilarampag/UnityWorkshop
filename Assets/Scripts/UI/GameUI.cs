using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject GameOverPanel;

    public void ShowWin()
    {
        WinPanel.SetActive(true);
    }

    public void ShowGameOver() {
        GameOverPanel.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
