using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LookableObject : InteractableObject
{
    [SerializeField] private Transform _originalTransform;
    private DepthOfField _depthOfField;
    protected float _clampedYInput = 0;
    protected float _clampedXInput = 0;
    private const float _rotationSpeed = 60;
    public override void StartInteracting()
    {
        base.StartInteracting();
        _interactableObject.transform.SetParent(Player.instance.GetLookableTransform());
        _interactableObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
        PostProcessingManager.instance.SetPostDepthOfField(true);
        LeanTween.move(_interactableObject, Player.instance.GetLookableTransform(), 3.5f * Time.deltaTime);
    }

    public override void StopInteracting()
    {
        base.StopInteracting();
        _interactableObject.transform.SetParent(transform);
        _interactableObject.transform.localRotation = new Quaternion(0,0,0,0);
        PostProcessingManager.instance.SetPostDepthOfField(false);
        LeanTween.move(_interactableObject, _originalTransform, 2 * Time.deltaTime);
    }

    public override void WhileInteracting()
    {
        base.WhileInteracting();
        _clampedYInput = Mathf.Clamp(Player.instance.GetPlayerInputActions().Player.Move.ReadValue<Vector2>().y, -1, 1);
        _clampedXInput = Mathf.Clamp(Player.instance.GetPlayerInputActions().Player.Move.ReadValue<Vector2>().x, -1, 1);
        _interactableObject.transform.Rotate(_interactableObject.transform.parent.up * (-_clampedXInput * _rotationSpeed * Time.deltaTime), Space.World);
        _interactableObject.transform.Rotate(_interactableObject.transform.parent.transform.right * (_clampedYInput * _rotationSpeed * Time.deltaTime), Space.World);
    }
}
