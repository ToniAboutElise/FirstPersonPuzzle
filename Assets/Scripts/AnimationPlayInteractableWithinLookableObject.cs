using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimationPlayInteractableWithinLookableObject : InteractableWithinLookableObject
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _animationClip;
    [SerializeField] private string _animatorKey;
    [SerializeField] private List<InteractableObject> _interactableObjectsToDisable = new List<InteractableObject>();
    [SerializeField] private GameObject _targetGameObjectToSet;
    [SerializeField] private TMP_Text _textToEnable;
    [SerializeField] private bool _setPosition;
    [SerializeField] private bool _setRotation;
    [SerializeField] private bool _enableText;
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
        LeanTween.value(0, 1, _animationClip.length - 0.2f).setOnComplete(() =>
          {
          LeanTween.value(0, 1, 0.8f).setOnUpdate((float value)=>
          {
              _textToEnable.color = new Color(_textToEnable.color.r, _textToEnable.color.g, _textToEnable.color.b, value);
          });
            gameObject.SetActive(false);
        });
    }
}
