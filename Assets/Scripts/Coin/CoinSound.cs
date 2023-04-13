using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSound : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _audioSource;

    public void AudioCollect()
    {
        _audioSource.PlayOneShot(_clip);
    }
}
