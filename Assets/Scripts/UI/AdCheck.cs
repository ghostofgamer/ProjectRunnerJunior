using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdCheck : MonoBehaviour
{
    [SerializeField] private SettingsScreen _settings;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void OnEnable()
    {
        AdButton.AdOpened += OnAdOpen;
        AdButton.AdClosed += OnAdClose;
    }

    private void OnDisable()
    {
        AdButton.AdOpened -= OnAdOpen;
        AdButton.AdClosed -= OnAdClose;
    }

    private void OnAdOpen()
    {
        _settings.Mute();
    }

    private void OnAdClose()
    {
        _settings.Unmute();
        _gameOverScreen.GetStatistics();
        _gameOverScreen.RewardInteractable();
    }
}
