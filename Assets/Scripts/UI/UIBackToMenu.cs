using UnityEngine;
using UnityEngine.UI;

public class UIBackToMenu : MonoBehaviour
{
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;

    void Awake()
    {
        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
    }

    private void OnYesButtonClicked()
    {
        SceneNavigation.LoadScene(Scenes.Menu);
    }

    private void OnNoButtonClicked()
    {
        gameObject.SetActive(false);
    }
}
