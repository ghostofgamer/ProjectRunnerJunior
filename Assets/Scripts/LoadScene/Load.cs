using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    private Player _player;
    public Transform positionPlayer;
    public GameObject[] players;

    private void Awake()
    {
        _player = Instantiate(players[PlayerPrefs.GetInt("Player")], positionPlayer.position, Quaternion.identity).GetComponent<Player>();
    }
}
