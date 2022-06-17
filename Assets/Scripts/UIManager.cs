using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private Image _interactiveImage;

    private void Awake()
    {
        if(instance == null)
        instance = this;

        SetInitialUIState();
    }

    public void SetInteractiveImageActive(bool setActive)
    {
        _interactiveImage.gameObject.SetActive(setActive);
    }

    private void SetInitialUIState()
    {
        SetInteractiveImageActive(false);
    }
}
