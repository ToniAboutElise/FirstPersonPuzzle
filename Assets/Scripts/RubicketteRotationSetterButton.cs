using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubicketteRotationSetterButton : InteractableObject
{
    public delegate void OnPress();
    public OnPress onPress;

    public override void StartInteracting()
    {
        if(_interactableState == InteractableState.INTERACTABLE) 
        {
            _interactableState = InteractableState.NON_INTERACTABLE;
            int targetRotation;
            if(transform.eulerAngles.z > 45)
            {
                targetRotation = -90;
            }
            else
            {
                targetRotation = 45;
            }
            onPress.Invoke();
            LeanTween.rotateAroundLocal(gameObject, new Vector3(0, 0, 0.7f), targetRotation, 1).setOnComplete(() =>
            {
                _interactableState = InteractableState.INTERACTABLE;
            });
        }
    }
}
