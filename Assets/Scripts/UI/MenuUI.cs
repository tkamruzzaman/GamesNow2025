using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button settingsButton;
    [SerializeField] Button exitButton;

    void Start()
    {

        playButton.onClick.AddListener(OnPlayButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        SceneNavigation.LoadScene(Scenes.Game);
    }

    private void OnSettingsButtonClicked()
    {
        Debug.Log("Settings button clicked - functionality not implemented yet.");
    }

    private void OnExitButtonClicked()
    {
#if UNITY_EDITOR
        if(UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
#else
        Application.Quit();
#endif
    }
}