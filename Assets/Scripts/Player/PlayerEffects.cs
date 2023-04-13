using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    [SerializeField] private GameObject _effect;
    [SerializeField] private ParticleSystem _effectMy;

    public void EffectOption(bool flag)
    {
        _effectMy.Play();
        _effect.SetActive(flag);
    }
}
