using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _coin;

    private Player _player;

    private void OnEnable()
    {
        try
        {
            _player.CoinsScoreChanged += OnCoinChanged;
        }
        catch
        {
            return;
        }
    }

    private void OnDisable()
    {
        _player.CoinsScoreChanged -= OnCoinChanged;
    }

    private void Start()
    {
        _player = FindObjectOfType<Player>().GetComponent<Player>();
    }

    private void OnCoinChanged(int score)
    {
        _coin.text = score.ToString();
    }
}
