using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class PauseScreen : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Score _score;
    [SerializeField] private InputPhoneScreen _inputPhoneScreen;

    private CanvasGroup _pauseGroup;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClick);
        _playButton.onClick.AddListener(OnPlayButtonClick);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
    }

    private void Start()
    {
        _pauseGroup = GetComponent<CanvasGroup>();
        _pauseGroup.alpha = 0;
        _pauseGroup.blocksRaycasts = false;
        InteractableButton(false);
    }

    public void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        _score.ChangePlaying(false);
        _pauseGroup.alpha = 1;
        _pauseGroup.blocksRaycasts = true;
        InteractableButton(true);

        if (_inputPhoneScreen == null)
        {
            return;
        }
        else
        _inputPhoneScreen.OffScreenInput();
    }

    private void OnPlayButtonClick()
    {
        _pauseGroup.alpha = 0;
        Time.timeScale = 1;
        _pauseGroup.blocksRaycasts = false;
        _score.ChangePlaying(true);
        _inputPhoneScreen.OnScreenInput();
    }

    private void InteractableButton(bool flag)
    {
        _playButton.interactable = flag;
        _menuButton.interactable = flag;
    }
}
