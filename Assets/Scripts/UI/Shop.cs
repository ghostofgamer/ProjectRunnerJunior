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
    [SerializeField] private Button _buyCowboyButton;
    [SerializeField] private Button _buyGirlButton;
    [SerializeField] private Button _winterBlock;
    [SerializeField] private Button _desertBlock;
    [SerializeField] private Button _bigManBlock;
    [SerializeField] private Button _ninjaBlock;

    private int coins;
    private int _desertAcsess;
    private int _winterAcsess;
    private int _bigManAcsess;
    private int _ninjaAcsess;
    private int _cowboyAcsess;
    private int _girlAcsess;
    private CanvasGroup _shopCanvas;
    private int _indexWinter = 2;
    private int _indexDesert = 1;
    private int _indexBigman = 4;
    private int _indexNinja = 5;
    private int _indexCowboy = 6;
    private int _indexGirl = 7;

    private void Awake()
    {
        _desertAcsess = PlayerPrefs.GetInt("desertLevel");
        _winterAcsess = PlayerPrefs.GetInt("winterLevel");
        _bigManAcsess = PlayerPrefs.GetInt("bigMan");
        _ninjaAcsess = PlayerPrefs.GetInt("ninja");
        _cowboyAcsess = PlayerPrefs.GetInt("cowboy");
        _girlAcsess = PlayerPrefs.GetInt("girl");
    }

    private void OnEnable()
    {
        menu.onClick.AddListener(ReturnToMenu);
        _buyDesertButton.onClick.AddListener(BuyDesertLevel);
        _buyWinterButton.onClick.AddListener(BuyWinterLevel);
        _buyBigManButton.onClick.AddListener(OnBuyBigMan);
        _buyNinjaButton.onClick.AddListener(OnBuyNinja);
        _buyCowboyButton.onClick.AddListener(OnBuyCowboy);
        _buyGirlButton.onClick.AddListener(OnBuyGirl);
    }

    private void OnDisable()
    {
        menu.onClick.RemoveListener(ReturnToMenu);
        _buyDesertButton.onClick.RemoveListener(BuyDesertLevel);
        _buyWinterButton.onClick.RemoveListener(BuyWinterLevel);
        _buyNinjaButton.onClick.RemoveListener(OnBuyNinja);
        _buyBigManButton.onClick.RemoveListener(OnBuyBigMan);
        _buyCowboyButton.onClick.RemoveListener(OnBuyCowboy);
        _buyGirlButton.onClick.RemoveListener(OnBuyGirl);
    }

    private void Start()
    {
        int money = PlayerPrefs.GetInt("money");
        int totalCoins = PlayerPrefs.GetInt("coin");
        coins = PlayerPrefs.GetInt("moneys") + totalCoins;
        AddCoins();
        PlayerPrefs.SetInt("moneys",coins);
        PlayerPrefs.SetInt("money", 0);
        PlayerPrefs.SetInt("coin", 0);
        coinUI.text = coins.ToString();
        _shopCanvas = GetComponent<CanvasGroup>();
        _shopCanvas.alpha = 0;
        _shopCanvas.blocksRaycasts = false;

        for (int i = 0; i < shopItemSO.Length; i++)
        {
            shopPanelsGo[i].SetActive(true);
        }

        if (_desertAcsess != 0)
        {
            myPurchaseBtns[_indexDesert].enabled = false;
            BuyBlock(_buyDesertButton);
        }

        if (_winterAcsess != 0)
        {
            myPurchaseBtns[_indexWinter].enabled = false;
            BuyBlock(_buyWinterButton);
        }

        if (_bigManAcsess != 0)
        {
            myPurchaseBtns[_indexBigman].enabled = false;
            BuyBlock(_buyBigManButton);
        }

        if (_ninjaAcsess != 0)
        {
            myPurchaseBtns[_indexNinja].enabled = false;
            BuyBlock(_buyNinjaButton);
        }

        if (_cowboyAcsess != 0)
        {
            myPurchaseBtns[_indexCowboy].enabled = false;
            BuyBlock(_buyCowboyButton);
        }

        if (_girlAcsess != 0)
        {
            myPurchaseBtns[_indexGirl].enabled = false;
            BuyBlock(_buyGirlButton);
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
        if (coins >= shopItemSO[_indexWinter].BaseCost)
        {
            coins = coins - shopItemSO[_indexWinter].BaseCost;
            PlayerPrefs.SetInt("coins", coins);
            PlayerPrefs.SetInt("moneys", coins);
            coinUI.text = coins.ToString();
            BuyBlock(_buyWinterButton);
            PlayerPrefs.SetInt("winterLevel", 1);
        }
    }

    private void BuyDesertLevel()
    {
        if (coins >= shopItemSO[_indexDesert].BaseCost)
        {
            coins = coins - shopItemSO[_indexDesert].BaseCost;
            PlayerPrefs.SetInt("coins", coins);
            PlayerPrefs.SetInt("moneys", coins);
            coinUI.text = coins.ToString();
            BuyBlock(_buyDesertButton);
            PlayerPrefs.SetInt("desertLevel", 1);
        }
    }

    private void OnBuyBigMan()
    {
        if (coins >= shopItemSO[_indexBigman].BaseCost)
        {
            coins = coins - shopItemSO[_indexBigman].BaseCost;
            PlayerPrefs.SetInt("coins", coins);
            PlayerPrefs.SetInt("moneys", coins);
            coinUI.text = coins.ToString();
            BuyBlock(_buyBigManButton);
            PlayerPrefs.SetInt("bigMan", 1);
        }
    }

    private void OnBuyNinja()
    {
        if (coins >= shopItemSO[_indexNinja].BaseCost)
        {
            coins = coins - shopItemSO[_indexNinja].BaseCost;
            PlayerPrefs.SetInt("coins", coins);
            PlayerPrefs.SetInt("moneys", coins);
            coinUI.text = coins.ToString();
            BuyBlock(_buyNinjaButton);
            PlayerPrefs.SetInt("ninja", 1);
        }
    }

    private void OnBuyCowboy()
    {
        if (coins >= shopItemSO[_indexCowboy].BaseCost)
        {
            coins = coins - shopItemSO[_indexCowboy].BaseCost;
            PlayerPrefs.SetInt("coins", coins);
            PlayerPrefs.SetInt("moneys", coins);
            coinUI.text = coins.ToString();
            BuyBlock(_buyCowboyButton);
            PlayerPrefs.SetInt("cowboy", 1);
        }
    }

    private void OnBuyGirl()
    {
        if (coins >= shopItemSO[_indexGirl].BaseCost)
        {
            coins = coins - shopItemSO[_indexGirl].BaseCost;
            PlayerPrefs.SetInt("coins", coins);
            PlayerPrefs.SetInt("moneys", coins);
            coinUI.text = coins.ToString();
            BuyBlock(_buyGirlButton);
            PlayerPrefs.SetInt("girl", 1);
        }
    }

    private void BuyBlock(Button button)
    {
        button.gameObject.SetActive(false);
    }
}
