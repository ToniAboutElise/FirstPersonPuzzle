using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LookableObject : InteractableObject
{
    [SerializeField] private Transform _originalTransform;
    private DepthOfField depthOfField;
    public override void StartInteracting()
    {
        base.StartInteracting();
        _interactableObject.transform.SetParent(Player.instance.GetLookableTransform());
        if(Player.instance.GetVolume().profile.TryGet<DepthOfField>(out depthOfField))
        {
            depthOfField.active = true;
        }
        //LeanTween.value(Player.instance.GetVolume().profile.TryGet<>)
        LeanTween.move(_interactableObject, Player.instance.GetLookableTransform(), 3.5f * Time.deltaTime);
    }

    public override void StopInteracting()
    {
        base.StopInteracting();
        _interactableObject.transform.SetParent(transform);
        if (Player.instance.GetVolume().profile.TryGet<DepthOfField>(out depthOfField))
        {
            depthOfField.active = false;
        }
        LeanTween.move(_interactableObject, _originalTransform, 2 * Time.deltaTime);
    }
}
