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

    private float _musicVolume = 1f;
    private int _firstPlayInt;
    private CanvasGroup _settingsGroup;

    private void OnEnable()
    {
        _offMusicButton.onClick.AddListener(OnOffMusicButtonClick);
        _acceptButton.onClick.AddListener(OnAcceptButtonClick);
    }

    private void OnDisable()
    {
        _offMusicButton.onClick.RemoveListener(OnOffMusicButtonClick);
        _acceptButton.onClick.RemoveListener(OnAcceptButtonClick);
    }

    private void Start()
    {
        _firstPlayInt = PlayerPrefs.GetInt("firstPlay");

        if (_firstPlayInt == 0)
        {
            _musicVolume = 0.3f;
            _slider.value = _musicVolume;
            PlayerPrefs.SetInt("firstPlay", 1);
        }
        else
        {
            _slider.value = PlayerPrefs.GetFloat("volume");
        }

        _settingsGroup = GetComponent<CanvasGroup>();
        _settingsGroup.alpha = 0;
        _settingsGroup.blocksRaycasts = false;
        InteractableButtons(false);
    }

    private void Update()
    {
        _musicVolume = _slider.value;
        _audioSource.volume = _musicVolume;
        PlayerPrefs.SetFloat("volume", _slider.value);
    }

    public void OnOffMusicButtonClick()
    {
        _slider.value = 0f;
    }

    public void ReturnSoundGame()
    {
        _audioSource.mute = false;
    }

    public void Off()
    {
        _audioSource.mute = true;
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
    }
}
