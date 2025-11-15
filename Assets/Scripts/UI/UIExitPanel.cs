using UnityEngine;
using UnityEngine.UI;

public class UIExitPanel : MonoBehaviour
{
    [SerializeField] Button confirmExitButton;
    [SerializeField] Button cancelExitButton;

    void Awake()
    {
        confirmExitButton.onClick.AddListener(OnConfirmExitButtonClicked);
        cancelExitButton.onClick.AddListener(OnCancelExitButtonClicked);
    }

    private void OnConfirmExitButtonClicked()
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

    private void OnCancelExitButtonClicked()
    {
        gameObject.SetActive(false);
    }
}