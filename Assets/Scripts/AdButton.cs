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
    public static event Action AdReward;

    private Player _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Click()
    {
        VideoAd.Show(Mute,Reward,Unmute);
    }

    public void Mute() => AdOpened?.Invoke();
    public void Unmute() => AdClosed?.Invoke();

    private void Reward() => _player.AddReward();

    //private void Rewards()
    //{
    //    _gameOverScreen.RewardsCoin();
    //}
}
