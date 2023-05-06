using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseFocusScreen : MonoBehaviour
{
    private CanvasGroup _focusCanvas;

    private void Start()
    {
        _focusCanvas = GetComponent<CanvasGroup>();
        _focusCanvas.alpha = 0;
        _focusCanvas.blocksRaycasts = false;
    }
}
