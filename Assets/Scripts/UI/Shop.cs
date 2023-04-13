using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameScreenMenu _gameScreenMenu;
    [SerializeField] private TMP_Text coinUI;
    [SerializeField] private ShopItemSO[] shopItemSO;
    [SerializeField] private GameObject[] shopPanelsGo;
    [SerializeField] private ShopTemplate[] shopPanels;
    [SerializeField] private Button[] myPurchaseBtns;
    [SerializeField] private Button menu;
    [SerializeField] private Player player;
    [SerializeField] private Button _buyDesertButton;
    [SerializeField] private Button _buyWinterButton;
    [SerializeField] private Button _buyBigManButton;
    [SerializeField] private Button _buyNinjaButton;
    [SerializeField] private Button _winterBlock;
    [SerializeField] private Button _desertBlock;
    [SerializeField] private Button _bigManBlock;
    [SerializeField] private Button _ninjaBlock;

    private int coins;
    private int _desertAcsess;
    private int _winterAcsess;
    private int _bigManAcsess;
    private int _ninjaAcsess;
    private CanvasGroup _shopCanvas;

    private void Awake()
    {
        _desertAcsess = PlayerPrefs.GetInt("desertLevel");
        _winterAcsess = PlayerPrefs.GetInt("winterLevel");
        _bigManAcsess = PlayerPrefs.GetInt("bigMan");
        _ninjaAcsess = PlayerPrefs.GetInt("ninja");
    }

    private void OnEnable()
    {
        menu.onClick.AddListener(ReturnToMenu);
        _buyDesertButton.onClick.AddListener(BuyDesertLevel);
        _buyWinterButton.onClick.AddListener(BuyWinterLevel);
        _buyBigManButton.onClick.AddListener(OnBuyBigMan);
        _buyNinjaButton.onClick.AddListener(OnBuyNinja);
    }

    private void OnDisable()
    {
        menu.onClick.RemoveListener(ReturnToMenu);
        _buyDesertButton.onClick.RemoveListener(BuyDesertLevel);
        _buyWinterButton.onClick.RemoveListener(BuyWinterLevel);
        _buyNinjaButton.onClick.RemoveListener(OnBuyNinja);
        _buyBigManButton.onClick.RemoveListener(OnBuyBigMan);
    }

    private void Start()
    {
        AddCoins();
        int totalCoins = PlayerPrefs.GetInt("coin");
        coins = PlayerPrefs.GetInt("coins") + totalCoins;
        PlayerPrefs.SetInt("coins", coins);
        _shopCanvas = GetComponent<CanvasGroup>();
        _shopCanvas.alpha = 0;
        _shopCanvas.blocksRaycasts = false;
        coinUI.text = coins.ToString();

        for (int i = 0; i < shopItemSO.Length; i++)
        {
            shopPanelsGo[i].SetActive(true);
        }

        if (_desertAcsess != 0)
        {
            myPurchaseBtns[1].enabled = false;
            BuyBlock(_buyDesertButton);
        }
        if (_winterAcsess != 0)
        {
            myPurchaseBtns[0].enabled = false;
            BuyBlock(_buyWinterButton);
        }
        if (_bigManAcsess != 0)
        {
            myPurchaseBtns[3].enabled = false;
            BuyBlock(_buyBigManButton);
        }
        if (_ninjaAcsess != 0)
        {
            myPurchaseBtns[4].enabled = false;
            BuyBlock(_buyNinjaButton);
        }
        LoadPanels();
        CheckPurchaseable();
    }

    public void AddCoins()
    {
        coinUI.text = coins.ToString();
        CheckPurchaseable();
    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            shopPanels[i].TitleText.text = shopItemSO[i].Title;
            shopPanels[i].DescriptionTxt.text = shopItemSO[i].Description;
            shopPanels[i].CostTxt.text = shopItemSO[i].BaseCost.ToString();
            shopPanels[i].ImageItem.sprite = shopItemSO[i].Sprite;
        }
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            if (coins >= shopItemSO[i].BaseCost)
            {
                myPurchaseBtns[i].interactable = true;
            }
            else
            {
                myPurchaseBtns[i].interactable = false;
            }
        }
    }

    public void OpenShopScreen()
    {
        _shopCanvas.blocksRaycasts = true;
        _shopCanvas.alpha = 1;
        CheckPurchaseable();
    }

    private void ReturnToMenu()
    {
        _shopCanvas.alpha = 0;
        Time.timeScale = 1;
        _shopCanvas.blocksRaycasts = false;
        _gameScreenMenu.OpenScreen();
    }

    private void BuyWinterLevel()
    {
        if (coins >= shopItemSO[0].BaseCost)
        {
            coins = coins - shopItemSO[0].BaseCost;
            PlayerPrefs.SetInt("coins", coins);
            coinUI.text = coins.ToString();
            BuyBlock(_buyWinterButton);
            PlayerPrefs.SetInt("winterLevel", 1);
        }
    }

    private void BuyDesertLevel()
    {
        if (coins >= shopItemSO[1].BaseCost)
        {
            coins = coins - shopItemSO[1].BaseCost;
            PlayerPrefs.SetInt("coins", coins);
            coinUI.text = coins.ToString();
            BuyBlock(_buyDesertButton);
            PlayerPrefs.SetInt("desertLevel", 1);
        }
    }

    private void OnBuyBigMan()
    {
        if (coins >= shopItemSO[3].BaseCost)
        {
            coins = coins - shopItemSO[3].BaseCost;
            PlayerPrefs.SetInt("coins", coins);
            coinUI.text = coins.ToString();
            BuyBlock(_buyBigManButton);
            PlayerPrefs.SetInt("bigMan", 1);
        }
    }

    private void OnBuyNinja()
    {
        if (coins >= shopItemSO[4].BaseCost)
        {
            coins = coins - shopItemSO[4].BaseCost;
            PlayerPrefs.SetInt("coins", coins);
            coinUI.text = coins.ToString();
            BuyBlock(_buyNinjaButton);
            PlayerPrefs.SetInt("ninja", 1);
        }
    }

    private void BuyBlock(Button button)
    {
        button.gameObject.SetActive(false);
    }
}
