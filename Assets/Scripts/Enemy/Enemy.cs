using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
