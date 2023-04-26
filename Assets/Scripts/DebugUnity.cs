using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUnity : MonoBehaviour
{
    [SerializeField] private SettingsScreen _settings;
    [SerializeField] private PauseScreen _pauseScreen;

    bool isPaused = false;

    private void OnGUI()
    {
        if (isPaused)
        {
            _settings.Off();
            _pauseScreen.OnPauseButtonClick();
        }
        else
        {
            _settings.ReturnSoundGame();
        }
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        isPaused = !hasFocus;
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
    }
}
