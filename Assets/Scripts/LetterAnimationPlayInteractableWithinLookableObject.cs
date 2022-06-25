using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LetterAnimationPlayInteractableWithinLookableObject : AnimationPlayInteractableWithinLookableObject
{
    [SerializeField] private TMP_Text _textContinue;
    [SerializeField] private GameObject _buttonContinue;
    public override void ActionOnInteract()
    {
        base.ActionOnInteract();
        LeanTween.value(0, 1, 10).setOnComplete(() => 
        {
            _buttonContinue.gameObject.SetActive(true);

            LeanTween.value(0, 1, 2).setOnUpdate((float value) =>
            {
                _textContinue.color = new Color(_textContinue.color.r, _textContinue.color.g, _textContinue.color.b, value);
            });
            GameManager.instance.GetEventSystem().SetSelectedGameObject(_buttonContinue.gameObject);
        });
    }

    public void Test()
    {
        Debug.Log("YES");
    }
}
