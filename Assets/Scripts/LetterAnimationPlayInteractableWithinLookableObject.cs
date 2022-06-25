using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterAnimationPlayInteractableWithinLookableObject : AnimationPlayInteractableWithinLookableObject
{
    [SerializeField] private UIButton _uiButton;
    public override void ActionOnInteract()
    {
        base.ActionOnInteract();
        LeanTween.value(0, 1, 10).setOnComplete(() => 
        {
            _uiButton.gameObject.SetActive(true);

            LeanTween.value(0, 1, 2).setOnUpdate((float value) =>
            {
                _uiButton.GetText().color = new Color(_uiButton.GetText().color.r, _uiButton.GetText().color.g, _uiButton.GetText().color.b, value);
            });
            _uiButton.GetButton().GetComponent<Button>().Select();
        });
    }

    public void Test()
    {
        Debug.Log("YES");
    }
}
