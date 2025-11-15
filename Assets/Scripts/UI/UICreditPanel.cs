using UnityEngine;
using UnityEngine.UI;

public class UICreditPanel : MonoBehaviour
{
    [SerializeField] Button closeButton;

    void Awake()
    {
        closeButton.onClick.AddListener(OnCloseButtonClicked);
    }

    private void OnCloseButtonClicked()
    {
        gameObject.SetActive(false);
    }
}
