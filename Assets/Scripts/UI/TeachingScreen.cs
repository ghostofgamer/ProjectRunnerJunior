using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeachingScreen : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private CanvasGroup _teachingCanvasGroup;
    [SerializeField] private InputPhoneScreen _inputPhoneScreen;
    [SerializeField] private Timer _timer;

    private bool _stop;

    public bool Stop => _stop;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
    }

    private void Start()
    {
        Time.timeScale = 0;
        _teachingCanvasGroup.alpha = 1;
        _playButton.interactable = true;
        _teachingCanvasGroup.blocksRaycasts = true;
        _inputPhoneScreen.OffScreenInput();
        _stop = true;
    }

    public void OnPlayButtonClick()
    {
        _timer.StartToTimer();
        Time.timeScale = 1;
        _teachingCanvasGroup.alpha = 0;
        _playButton.interactable = false;
        _teachingCanvasGroup.blocksRaycasts = false;
        _inputPhoneScreen.OnScreenInput();
        _stop = false;
    }
}
