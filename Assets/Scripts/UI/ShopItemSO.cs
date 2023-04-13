using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ShopMenu", menuName = "Scriptable Objects/New Shop Item", order = 51)]
public class ShopItemSO : ScriptableObject
{
    [SerializeField] private string _title;
    [SerializeField]private  string _description;
    [SerializeField] private int _baseCost;
    [SerializeField] private Sprite _sprite;

    public string Description => _description;
    public string Title => _title;
    public int BaseCost => _baseCost;
    public Sprite Sprite => _sprite;
}
