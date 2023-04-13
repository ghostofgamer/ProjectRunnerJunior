using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private float _lastTimeAddedScore;

    private bool _isPlaying = true;
    private float _elapsedTime = 0f;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
    }

    private void Update()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (_isPlaying)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _lastTimeAddedScore)
            {
                _player.IncreaseScore();
            }
        }
    }

    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
    }

    public void ChangePlaying(bool flag)
    {
        _isPlaying = flag;
    }
}
