using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;
using Agava.YandexGames.Samples;

public class InterScreen : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Button _button1;

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
        InterstitialAd.Show();
    }

}
