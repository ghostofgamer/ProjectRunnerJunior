using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    private Player _player;

    //private void Awake()
    //{
    //}

    private void Start()
    {
        _player= GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //_player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _player.Die();
        }

        if(other.TryGetComponent(out Coin coin))
        {
            _player.AddedCoin();
            coin.CollectionCoin();
        }
    }
}
