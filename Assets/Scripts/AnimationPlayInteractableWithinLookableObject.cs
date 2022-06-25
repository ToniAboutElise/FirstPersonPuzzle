using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayInteractableWithinLookableObject : InteractableWithinLookableObject
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _animationClip;
    [SerializeField] private string _animatorKey;
    [SerializeField] private InteractableWithinLookableObject _nextInteractableWithinLookableObject;

    public override void StartInteracting()
    {
        ActionOnInteract();
    }

    public override void ActionOnInteract()
    {
        _animator.SetTrigger(_animatorKey);
        LeanTween.value(0, 1, _animationClip.length).setOnComplete(() =>
        {
            _nextInteractableWithinLookableObject.GetCollider().enabled = true;
            GetCollider().enabled = false;
            enabled = false;
        });
    }
}
