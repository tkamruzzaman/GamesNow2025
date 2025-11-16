using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button pauseButton;
    [SerializeField] Button backToMenuButton;

    [Header("Panels")]
    [SerializeField] UIPausePanel pausePanel;
    [SerializeField] UIBackToMenu backToMenuPanel;
    [SerializeField] UIGameOverPanel gameOverPanel;

    void Awake()
    {
        pauseButton.onClick.AddListener(OnPauseButtonClicked);
        backToMenuButton.onClick.AddListener(OnBackToMenuButtonClicked);

        pausePanel.gameObject.SetActive(false);
        backToMenuPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
    }

    private void OnPauseButtonClicked()
    {
        Time.timeScale = 0f;
        pausePanel.gameObject.SetActive(true);
    }

    private void OnBackToMenuButtonClicked()
    {
        backToMenuPanel.gameObject.SetActive(true);
    }

    public void ShowGameOverPanel(bool isSuccess)
    {
        gameOverPanel.ShowGameOver(isSuccess);
        gameOverPanel.gameObject.SetActive(true);
    }
}
