using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    CanvasGroup canvasGroup;
    KeyCode pauseKey = KeyCode.Escape;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            canvasGroup.alpha = (canvasGroup.alpha == 1) ? 0 : 1;
            canvasGroup.interactable = !canvasGroup.interactable;
        }
    }
}
