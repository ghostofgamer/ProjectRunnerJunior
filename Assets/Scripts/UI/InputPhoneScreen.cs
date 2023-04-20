using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class InputPhoneScreen : MonoBehaviour
{
    [SerializeField] private Button _rightButton;
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _jumpButton;

    private CanvasGroup _canvasGroup;

    public void InteractableButton(bool flag)
    {
        _rightButton.interactable = flag;
        _leftButton.interactable = flag;
        _jumpButton.interactable = flag;
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void BlockRaycastsChange(bool flag)
    {
        _canvasGroup.blocksRaycasts = flag;
    }

    public void AlphaScreen()
    {

    }

    public void OnScreenInput()
    {
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1f;
    }

    public void OffScreenInput()
    {
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0f;
    }
}
