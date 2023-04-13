using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _menuButton;
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _scoreUI;
    [SerializeField] private TMP_Text _coinUI;

    private Player _player;
    private CanvasGroup _gameOverGroup;
    private int _scores;
    private int _coins;

    private void OnEnable()
    {
        _player.Died += OnDied;
        _menuButton.onClick.AddListener(OnMenuButtonClick);
    }

    private void OnDisable()
    {
        _player.Died += OnDied;
        _menuButton.onClick.RemoveListener(OnMenuButtonClick);
    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
        _gameOverGroup.blocksRaycasts = false;
        InteractableButton(false);
    }

    private void OnDied()
    {
        _gameOverGroup.alpha = 1;
        _gameOverGroup.blocksRaycasts = true;
        Time.timeScale = 0;
        InteractableButton(true);
        GetStatistics();
        _score.ChangePlaying(false); 
    }

    private void InteractableButton(bool flag)
    {
        _menuButton.interactable = flag;
    }

    private void GetStatistics()
    {
        _scores = PlayerPrefs.GetInt("score");
        _coins = PlayerPrefs.GetInt("coin");
        _scoreUI.text = _scores.ToString();
        _coinUI.text = _coins.ToString();
    }

    private void OnMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
