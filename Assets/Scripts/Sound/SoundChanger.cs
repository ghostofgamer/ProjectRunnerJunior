using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundChanger : MonoBehaviour
{
    [SerializeField] private Button _muteButton;
    [SerializeField] private Button _unmuteButton;
    [SerializeField] private AudioSource _audio;

    private void OnEnable()
    {
        _muteButton.onClick.AddListener(OnMuteButtonClick);
        _unmuteButton.onClick.AddListener(OnUnmuteButtonClick);
    }

    private void OnDisable()
    {
        _muteButton.onClick.RemoveListener(OnMuteButtonClick);
        _unmuteButton.onClick.RemoveListener(OnUnmuteButtonClick);
        
    }

    private void OnMuteButtonClick() 
    {
        Time.timeScale = 0;
        _audio.mute = true;
    }
    private void OnUnmuteButtonClick() 
    { 
        _audio.mute = false;
    }
}
