using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;
using Agava.YandexGames.Samples;

public class InterScreen : MonoBehaviour
{
    [SerializeField] private Button _button;

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnShowInterstitialButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnShowInterstitialButtonClick);
    }

    public void OnShowInterstitialButtonClick()
    {
        InterstitialAd.Show();
    }

}
