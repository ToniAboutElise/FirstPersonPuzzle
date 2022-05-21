using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookableObject : InteractableObject
{
    [SerializeField] private Transform _originalTransform;
    public override void StartInteracting()
    {
        base.StartInteracting();
        _interactableObject.transform.SetParent(Player.instance.GetLookableTransform());
        LeanTween.move(_interactableObject, Player.instance.GetLookableTransform(), 3.5f * Time.deltaTime);
    }

    public override void StopInteracting()
    {
        base.StopInteracting();
        _interactableObject.transform.SetParent(transform);
        LeanTween.move(_interactableObject, _originalTransform, 2 * Time.deltaTime);
    }
}
