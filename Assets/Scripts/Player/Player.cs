using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _score;
    private int _coin;

    public event UnityAction<int> ScoreChanged; 
    public event UnityAction<int> CoinsScoreChanged; 
    public event UnityAction Died;

    public int Coin => _coin;

    private void Start()
    {
        ResetPlayer();
        PlayerPrefs.SetInt("coin", _coin);
    }
    public void Die()
    {
        PlayerPrefs.SetInt("score", _score);
        Died?.Invoke();
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void AddedCoin()
    {
        _coin++;
        CoinsScoreChanged?.Invoke(_coin);
        PlayerPrefs.SetInt("coin", _coin);
    }

    public void ResetPlayer()
    {
        _score = 0;
        _coin = 0;
        ScoreChanged?.Invoke(_score);
        CoinsScoreChanged?.Invoke(_coin);
    }
}
