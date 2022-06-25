using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterAnimationPlayInteractableWithinLookableObject : AnimationPlayInteractableWithinLookableObject
{
    [SerializeField] private GameObject _buttonContinue;
    public override void ActionOnInteract()
    {
        base.ActionOnInteract();
        LeanTween.value(0, 1, 7).setOnComplete(() => 
        {
            _buttonContinue.SetActive(true);
            LeanTween.alpha(_buttonContinue, 1, 1);
        });
    }
}
