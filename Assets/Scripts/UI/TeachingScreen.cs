using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeachingScreen : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private CanvasGroup _teachingCanvasGroup;

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
    }

    private void OnPlayButtonClick()
    {
        Time.timeScale = 1;
        _teachingCanvasGroup.alpha = 0;
        _playButton.interactable = false;
        _teachingCanvasGroup.blocksRaycasts = false;
    }
}
