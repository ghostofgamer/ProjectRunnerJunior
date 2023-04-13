using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _zOffset;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z - _zOffset);
    }
}
