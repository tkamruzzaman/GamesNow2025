using UnityEngine;
using UnityEngine.UI;

public class UISettingsPanel : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button closeButton;

    [Header("Toggles")]
    [SerializeField] Toggle musicToggle;
    [SerializeField] Toggle soundToggle;
    [Header("Sprites")]
    [SerializeField] Sprite musicOnSprite;
    [SerializeField] Sprite musicOffSprite;
    [SerializeField] Sprite soundOnSprite;
    [SerializeField] Sprite soundOffSprite;

    void Awake()
    {
        musicToggle.onValueChanged.AddListener( OnMusicButtonClicked);
        soundToggle.onValueChanged.AddListener(OnSoundButtonClicked);
        closeButton.onClick.AddListener(OnCloseButtonClicked);
    }

    private void OnMusicButtonClicked(bool isOn)
    {
        musicToggle.image.sprite = isOn ? musicOnSprite : musicOffSprite;
    }

    private void OnSoundButtonClicked(bool isOn)
    {
        soundToggle.image.sprite = isOn ? soundOnSprite : soundOffSprite;
    }

    private void OnCloseButtonClicked()
    {
        gameObject.SetActive(false);
    }
}
