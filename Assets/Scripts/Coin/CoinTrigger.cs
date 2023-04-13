using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
            //transform.Translate(-Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Destroyer destroyer))
        {
            gameObject.SetActive(false);
        }
    }
}
