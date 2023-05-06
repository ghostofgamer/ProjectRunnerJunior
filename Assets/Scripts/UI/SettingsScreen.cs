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

    private float _musicVolume = 1f;
    private int _firstPlayInt;
    private CanvasGroup _settingsGroup;
    private int _muteCheck;

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
        _muteCheck = PlayerPrefs.GetInt("mute");

        //if (_muteCheck > 0)
        //{
        //    _audioSource.mute = true;
        //}

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

    public void Unmute(bool flag)
    {
        _audioSource.mute = false;
        PlayerPrefs.SetInt("mute", 1);
        Time.timeScale = 1;
    }

    public void Off()
    {
        _audioSource.mute = true;
        Time.timeScale = 0;
        PlayerPrefs.SetInt("mute", 0);
    }

    public void OnMusicButtonClick()
    {
        _slider.value = PlayerPrefs.GetFloat("volume");
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
