using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWithinLookableObject : InteractableObject
{
    [SerializeField] private Collider _collider;

    public Collider GetCollider() { return _collider; }

    public override void StartInteracting()
    {
        FirstPersonController.instance.SetCanMoveAndJump(false);
        _interactableObject.transform.SetParent(Player.instance.GetLookableTransform());
        _interactableObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
        LeanTween.move(_interactableObject, Player.instance.GetLookableTransform(), 3.5f * Time.deltaTime);
    }

    public override void StopInteracting()
    {

    }

    public virtual void ActionOnInteract()
    {

    }
}
