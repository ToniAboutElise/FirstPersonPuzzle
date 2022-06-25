using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterIntroLookableObject : LookableObject
{
    private void Start()
    {
        StartInteracting();   
    }

    public override void StartInteracting()
    {
        FirstPersonController.instance.SetCanMoveAndJump(false);
        _interactableObject.transform.SetParent(Player.instance.GetLookableTransform());
        _interactableObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
        LeanTween.move(_interactableObject, Player.instance.GetLookableTransform(), 3.5f * Time.deltaTime);
        //Player.instance.SetCurrentInteractableObject(this);
    }

    public override void StopInteracting()
    {
        
    }

    private void Rotation()
    {
        _clampedYInput = Mathf.Clamp(Player.instance.GetPlayerInputActions().Player.Move.ReadValue<Vector2>().y, -1, 1);
        _clampedXInput = Mathf.Clamp(Player.instance.GetPlayerInputActions().Player.Move.ReadValue<Vector2>().x, -1, 1);
        _interactableObject.transform.RotateAround(_interactableObject.transform.parent.position, new Vector3(-_clampedYInput * 4, -_clampedXInput * 4, 0), 1);
    }
    private void FixedUpdate()
    {
        Rotation();
    }
}
