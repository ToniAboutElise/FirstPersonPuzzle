using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class LetterAnimationPlayInteractableWithinLookableObject : AnimationPlayInteractableWithinLookableObject
{
    [SerializeField] private ColorAdjustments _colorAdjustments;
    [SerializeField] private UIButton _uiButton;
    public override void ActionOnInteract()
    {
        base.ActionOnInteract();
        LeanTween.value(0, 1, 10).setOnComplete(() => 
        {
            LeanTween.value(0, 1, 2).setOnUpdate((float value) =>
            {
                _uiButton.GetText().color = new Color(_uiButton.GetText().color.r, _uiButton.GetText().color.g, _uiButton.GetText().color.b, value);
            });
            _uiButton.GetButton().gameObject.SetActive(true);
            _uiButton.GetButton().GetComponent<Button>().Select();
        });
    }

    public void Test()
    {
        if (Player.instance.GetVolume().profile.TryGet<ColorAdjustments>(out _colorAdjustments))
        {
            _colorAdjustments.active = true;
            LeanTween.value(0, -30, 8).setOnUpdate((float value) =>
            {
                _colorAdjustments.postExposure.value = value;
                if(value == -30)
                {
                    GameManager.instance.LoadScene("Demo");
                }
            });
        }
    }
}
