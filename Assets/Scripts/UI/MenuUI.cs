using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button playButton;
    [SerializeField] Button creditButton;
    [SerializeField] Button settingsButton;
    [SerializeField] Button exitButton;
    [Header("Panels")]
    [SerializeField] UICreditPanel creditPanel;
    [SerializeField] UISettingsPanel settingsPanel;
    [SerializeField] UIExitPanel exitPanel;

    void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        creditButton.onClick.AddListener(OnCreditButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        
        creditPanel.gameObject.SetActive(false);
        settingsPanel.gameObject.SetActive(false);
        exitPanel.gameObject.SetActive(false);
    }

    private void OnPlayButtonClicked()
    {
        SceneNavigation.LoadScene(Scenes.Game);
    }

    private void OnCreditButtonClicked()
    {
        creditPanel.gameObject.SetActive(true);
    }

    private void OnSettingsButtonClicked()
    {
        settingsPanel.gameObject.SetActive(true);
    }

    private void OnExitButtonClicked()
    {
        exitPanel.gameObject.SetActive(true);
    }
}