using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameOverPanel : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button restartButton;
    [SerializeField] Button nextLevelButton;

    [Header("Texts")]
    [SerializeField] TMP_Text gameoverText;
    string successText = "Yes! That’s my cutie!";
    string failureText = "Time’s up… That wasn’t my cutie…";

    void Awake()
    {
        gameoverText.text = "";
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        nextLevelButton.onClick.AddListener(OnNextLevelButtonClicked);
    }

    private void OnRestartButtonClicked()
    {
        SceneNavigation.LoadScene(Scenes.Game);
    }

    private void OnNextLevelButtonClicked()
    {
        SceneNavigation.LoadScene(Scenes.Game);
    }

    public void ShowGameOver(bool isSuccess)
    {
        gameoverText.text = isSuccess ? successText : failureText;
    }


}
