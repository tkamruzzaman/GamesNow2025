using UnityEngine;
using UnityEngine.UI;

public class UIPausePanel : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button restartButton;
    [SerializeField] Button closeButton;

    void Awake()
    {
        resumeButton.onClick.AddListener(OnResumeButtonClicked);
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        closeButton.onClick.AddListener(OnCloseButtonClicked);
    }

    private void OnResumeButtonClicked()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    private void OnRestartButtonClicked()
    {
        Time.timeScale = 1f;
        SceneNavigation.LoadScene(Scenes.Game);
    }

    private void OnCloseButtonClicked()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
