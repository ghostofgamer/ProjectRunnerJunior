using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopTemplate : MonoBehaviour
{
    [SerializeField]private TMP_Text _titleText;
    [SerializeField] private TMP_Text _descriptionTxt;
    [SerializeField] private TMP_Text _costTxt;
    [SerializeField] private Image _imageItem;

    public TMP_Text TitleText => _titleText;
    public TMP_Text DescriptionTxt => _descriptionTxt;
    public TMP_Text CostTxt => _costTxt;
    public Image ImageItem => _imageItem;
}
