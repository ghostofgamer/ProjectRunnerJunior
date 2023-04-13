using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinScore : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _coin;
    [SerializeField] private CoinSound _coinSound;

    private void Start()
    {
        
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.CoinsScoreChanged += OnCoinChanged;
    }

    private void OnDisable()
    {
        _player.CoinsScoreChanged -= OnCoinChanged;
    }

    private void OnCoinChanged(int score)
    {
        _coin.text = score.ToString();
        _coinSound.AudioCollect();
    }
}
