using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
public class GameScreenMenu : MonoBehaviour
{
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _level1Button;
    [SerializeField] private Button _level2Button;
    [SerializeField] private Button _level3Button;
    [SerializeField] private Button[] _levelButtons;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _bigManButton;
    [SerializeField] private Button _ninjaButton;
    [SerializeField] private Button _simpleButton;
    [SerializeField] private Player _player;
    [SerializeField] private SettingsScreen _settingsScreen;
    [SerializeField] private Score _score;
    [SerializeField] private Shop _shop;
    [SerializeField] private GameObject _blockLvlDesert;
    [SerializeField] private GameObject _blockLvlWinter;
    [SerializeField] private GameObject _blockSkinBigMan;
    [SerializeField] private GameObject _blockSkinNinja;

    private CanvasGroup _gameMenuGroup;
    private int _desertLevel;
    private int _winterLevel;
    private int _skinBigMan;
    private int _skinNinja;
    private int _bestScore;

    public Button Level2 => _level2Button;
    public Button Level3 => _level3Button;
    public Button[] LevelButtons => _levelButtons;



    private int _scores;
    [SerializeField] private TMP_Text _scoreUI;

    private void OnEnable()
    {
        _settingsButton.onClick.AddListener(OnSettingsButtonClick);
        _level1Button.onClick.AddListener(OnBeachLevelButtonClick);
        _level2Button.onClick.AddListener(OnDesertLevelButtonClick);
        _level3Button.onClick.AddListener(OnWinterButtonClick);
        _shopButton.onClick.AddListener(OnShopButtonClick);
    }

    private void OnDisable()
    {
        _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
        _level1Button.onClick.RemoveListener(OnBeachLevelButtonClick);
        _level2Button.onClick.RemoveListener(OnDesertLevelButtonClick);
        _level3Button.onClick.RemoveListener(OnWinterButtonClick);
        _shopButton.onClick.RemoveListener(OnShopButtonClick);
    }

    private void Start()
    {
        _gameMenuGroup = GetComponent<CanvasGroup>();
        _gameMenuGroup.alpha = 1;
        InteractableButton(true);
        Time.timeScale = 1;
        _score.ChangePlaying(false);
        _bestScore = PlayerPrefs.GetInt("bestScore");
        _scores = PlayerPrefs.GetInt("score");

        if (_scores > _bestScore)
        {
            _bestScore = _scores;
            PlayerPrefs.SetInt("bestScore", _bestScore);
        }
        _scoreUI.text = _bestScore.ToString();
    }

    private void Update()
    {
        _desertLevel = PlayerPrefs.GetInt("desertLevel");
        _winterLevel = PlayerPrefs.GetInt("winterLevel");
        _skinBigMan = PlayerPrefs.GetInt("bigMan");
        _skinNinja = PlayerPrefs.GetInt("ninja");

        if (_desertLevel != 0)
        {
            //_level2Button.interactable = true;
            _blockLvlDesert.SetActive(false);
        }

        if (_winterLevel != 0)
        {
            //_level3Button.interactable = true;
            _blockLvlWinter.SetActive(false);
        }

        if (_skinBigMan != 0)
        {
            _blockSkinBigMan.SetActive(false);
        }

        if (_skinNinja != 0)
        {
            _blockSkinNinja.SetActive(false);

        }
    }

    private void OnSettingsButtonClick()
    {
        _settingsScreen.OpenSettingsScreen();
        _gameMenuGroup.alpha = 0;
        _gameMenuGroup.blocksRaycasts = false;
        InteractableButton(false);
    }

    public void OpenScreen()
    {
        _gameMenuGroup.alpha = 1;
        InteractableButton(true);
        _gameMenuGroup.blocksRaycasts = true;
    }

    private void OnBeachLevelButtonClick()
    {
        InteractableButton(false);
        ChangeLevel(1);
    }

    private void OnDesertLevelButtonClick()
    {
        InteractableButton(false);
        ChangeLevel(2);
    }

    private void OnWinterButtonClick()
    {
        InteractableButton(false);
        ChangeLevel(3);
    }

    private void InteractableButton(bool flag)
    {
        _settingsButton.interactable = flag;
        _level1Button.interactable = flag;
        _level2Button.interactable = flag;
        _level3Button.interactable = flag;
        _shopButton.interactable = flag;
    }

    private void ChangeLevel(int number)
    {
        InteractableButton(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(number);

        _score.ChangePlaying(true);
    }

    private void OnShopButtonClick()
    {
        _gameMenuGroup.alpha = 0;
        _gameMenuGroup.blocksRaycasts = false;
        _shop.OpenShopScreen();
        InteractableButton(false);
    }

    public void InteractableLevel(Button button)
    {
        button.interactable = true;
    }

    public void SetPlayer(int index)
    {
        PlayerPrefs.SetInt("Player", index);
    }
}
