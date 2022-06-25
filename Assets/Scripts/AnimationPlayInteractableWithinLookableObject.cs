using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayInteractableWithinLookableObject : InteractableWithinLookableObject
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _animationClip;
    [SerializeField] private string _animatorKey;
    [SerializeField] private List<InteractableObject> _interactableObjectsToDisable = new List<InteractableObject>();
    [SerializeField] private GameObject _targetGameObjectToSet;
    [SerializeField] private bool _setPosition;
    [SerializeField] private bool _setRotation;
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private Vector3 _targetRotation;

    public override void StartInteracting()
    {
        ActionOnInteract();
    }

    public override void ActionOnInteract()
    {
        GetCollider().enabled = false;

        if(_targetGameObjectToSet != null)
        {
            if(_setPosition)
            {
                LeanTween.moveLocal(_targetGameObjectToSet, _targetPosition, 0.5f);
            }

            if (_setRotation)
            {
                LeanTween.rotateLocal(_targetGameObjectToSet, _targetRotation, 0.8f);
            }
        }

        _animator.SetTrigger(_animatorKey);
        foreach (InteractableObject interactableObject in _interactableObjectsToDisable)
        {
            interactableObject.enabled = false;
        }
        LeanTween.value(0, 1, _animationClip.length).setOnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
