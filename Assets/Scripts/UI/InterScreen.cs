using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;
using Agava.YandexGames.Samples;
using System;
using UnityEngine.SceneManagement;

public class InterScreen : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Button _button1;
    [SerializeField] private SettingsScreen _settings;
    [SerializeField] private AdButton _adButton;

    public event Action InterOpen;
    public event Action InterClose;
    public event Action<bool> InterClosedInter;

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnShowInterstitialButtonClick);
        _button1.onClick.AddListener(OnShowInterstitialButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnShowInterstitialButtonClick);
        _button1.onClick.RemoveListener(OnShowInterstitialButtonClick);
    }

    public void OnShowInterstitialButtonClick()
    {
        InterstitialAd.Show(OnOpen, OnClose);
    }

    private void OnOpen()
    {
        _adButton.Mute();
    }

    private void OnClose(bool obj)
    {
        _adButton.Unmute();
        SceneManager.LoadScene(0);
    }

    private void Mute() => InterOpen?.Invoke();
    private void Unmute() => InterClose?.Invoke();
    private void Unmutes() => InterClosedInter?.Invoke(false);
}
