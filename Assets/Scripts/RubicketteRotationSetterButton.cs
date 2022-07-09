using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubicketteRotationSetterButton : InteractableObject
{
    public delegate void OnPress();
    public OnPress onPress;

    public override void StartInteracting()
    {
        LeanTween.rotateAroundLocal(gameObject, new Vector3(0, 0, 1), 90, 2).setOnComplete(() =>
        {
            onPress.Invoke();
        });
    }
}
