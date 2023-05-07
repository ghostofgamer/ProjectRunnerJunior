using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class SettingsScreen : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _offMusicButton;
    [SerializeField] private Button _acceptButton;
    [SerializeField] private GameScreenMenu _gameScreenMenu;
    [SerializeField] private Button _russianLanguage;
    [SerializeField] private Button _englishLanguage;
    [SerializeField] private Button _turceLanguage;

    private int _firstPlayInt;
    private CanvasGroup _settingsGroup;

    private void OnEnable()
    {
        _offMusicButton.onClick.AddListener(OffVolumeSound);
        _acceptButton.onClick.AddListener(OnAcceptButtonClick);
    }

    private void OnDisable()
    {
        _offMusicButton.onClick.RemoveListener(OffVolumeSound);
        _acceptButton.onClick.RemoveListener(OnAcceptButtonClick);
    }

    private void Start()
    {
        _firstPlayInt = PlayerPrefs.GetInt("firstPlay");

        if (_firstPlayInt == 0)
        {
            _slider.value = 0.3f;
            _audioSource.volume = _slider.value;
            PlayerPrefs.SetInt("firstPlay", 1);
        }
        else
        {
            _slider.value = PlayerPrefs.GetFloat("volume");
            _audioSource.volume = _slider.value;
        }

        _settingsGroup = GetComponent<CanvasGroup>();
        _settingsGroup.alpha = 0;
        _settingsGroup.blocksRaycasts = false;
        InteractableButtons(false);
    }

    public void SetVolume(float volume)
    {
        _slider.value = volume;
        _audioSource.volume = _slider.value;
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void OnVolumeSound()
    {
        _audioSource.volume = _slider.value;
    }

    public void OffVolumeSound()
    {
        _audioSource.volume = 0;
    }

    public void Unmute()
    {
        _audioSource.mute = false;
    }

    public void Mute()
    {
        _audioSource.mute = true;
        PlayerPrefs.SetInt("mute", 0);
    }

    private void OnAcceptButtonClick()
    {
        _gameScreenMenu.OpenScreen();
        _settingsGroup.alpha = 0;
        _settingsGroup.blocksRaycasts = false;
    }

    public void OpenSettingsScreen()
    {
        _settingsGroup.alpha = 1;
        _settingsGroup.blocksRaycasts = true;
        InteractableButtons(true);
    }

    private void InteractableButtons(bool flag)
    {
        _offMusicButton.interactable = flag;
        _acceptButton.interactable = flag;
        _russianLanguage.interactable = flag;
        _englishLanguage.interactable = flag;
        _turceLanguage.interactable = flag;
    }
}
