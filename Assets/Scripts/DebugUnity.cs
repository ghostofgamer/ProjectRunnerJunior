using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUnity : MonoBehaviour
{
    [SerializeField] private SettingsScreen _settings;
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private TeachingScreen _teachingScreen;
    [SerializeField] private PauseFocusScreen _pauseFocusScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Score _score;

    bool isPaused = false;

    private void OnGUI()
    {
        if (isPaused)
        {
            //_settings.Off();
            _settings.OnOffMusicButtonClick();
            StopPlay();
        }
        else
        {
            //_settings.ReturnSoundGame();
            _settings.OnMusicButtonClick();
            PlayGame();
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

    private void StopPlay()
    {
        _pauseFocusScreen.GetComponent<CanvasGroup>().alpha = 1;
        _pauseFocusScreen.GetComponent<CanvasGroup>().blocksRaycasts = true;
        _score.ChangePlaying(false);
        Time.timeScale = 0;
    }

    private void PlayGame()
    {
        _pauseFocusScreen.GetComponent<CanvasGroup>().alpha = 0;
        _pauseFocusScreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
        _score.ChangePlaying(true);

        if (_teachingScreen.GetComponent<CanvasGroup>().alpha == 0 && _gameOverScreen.GetComponent<CanvasGroup>().alpha == 0 && _pauseScreen.GetComponent<CanvasGroup>().alpha == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
