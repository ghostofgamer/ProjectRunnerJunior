using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames.Samples;
using Agava.YandexGames;

public class AdButton : MonoBehaviour
{
    [SerializeField] GameOverScreen _gameOverScreen;

    public static event Action AdOpened;
    public static event Action AdClosed;

    private Player _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void ClickRewardButton()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        VideoAd.Show(Mute,Reward,Unmute);
#endif
    }

    public void Mute() => AdOpened?.Invoke();
    public void Unmute() => AdClosed?.Invoke();
    private void Reward() => _player.AddReward();
}
