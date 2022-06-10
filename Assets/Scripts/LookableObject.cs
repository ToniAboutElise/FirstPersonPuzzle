using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LookableObject : InteractableObject
{
    [SerializeField] private Transform _originalTransform;
    private DepthOfField _depthOfField;
    private float _clampedYInput = 0;
    private float _clampedXInput = 0;
    public override void StartInteracting()
    {
        base.StartInteracting();
        _interactableObject.transform.SetParent(Player.instance.GetLookableTransform());
        _interactableObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
        if (Player.instance.GetVolume().profile.TryGet<DepthOfField>(out _depthOfField))
        {
            _depthOfField.active = true;
        }
        LeanTween.move(_interactableObject, Player.instance.GetLookableTransform(), 3.5f * Time.deltaTime);
    }

    public override void StopInteracting()
    {
        base.StopInteracting();
        _interactableObject.transform.SetParent(transform);
        _interactableObject.transform.localRotation = new Quaternion(0,0,0,0);
        if (Player.instance.GetVolume().profile.TryGet<DepthOfField>(out _depthOfField))
        {
            _depthOfField.active = false;
        }
        LeanTween.move(_interactableObject, _originalTransform, 2 * Time.deltaTime);
    }

    public override void WhileInteracting()
    {
        base.WhileInteracting();
        _clampedYInput = Mathf.Clamp(Player.instance.GetPlayerInputActions().Player.Camera.ReadValue<Vector2>().y, -1, 1);
        _clampedXInput = Mathf.Clamp(Player.instance.GetPlayerInputActions().Player.Camera.ReadValue<Vector2>().x, -1, 1);
        _interactableObject.transform.Rotate(new Vector3(_clampedYInput * 2, _clampedXInput * 2, 0), Space.Self);
    }
}
