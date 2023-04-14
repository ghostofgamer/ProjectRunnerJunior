using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class S : MonoBehaviour
{
    [SerializeField] private TMP_Text coinUI;

    private int coins;

    private void Start()
    {
        int totalCoins = PlayerPrefs.GetInt("coin");
        coins = PlayerPrefs.GetInt("coins") + totalCoins;
        PlayerPrefs.SetInt("coins", coins);
        coinUI.text = coins.ToString();
    }
}
