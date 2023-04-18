using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUnity : MonoBehaviour
{
    bool isPaused = false;
    [SerializeField] private SettingsScreen _settings;

    private void OnGUI()
    {
        if (isPaused)
        {
            _settings.Off();
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
