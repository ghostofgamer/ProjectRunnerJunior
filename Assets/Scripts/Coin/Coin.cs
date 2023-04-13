using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    private int _rotateSpeed=-1;


    private void Update()
    {
        transform.Rotate(0, _rotateSpeed, 0,Space.World);
    }

    public void CollectionCoin()
    {
        Instantiate(_effect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
