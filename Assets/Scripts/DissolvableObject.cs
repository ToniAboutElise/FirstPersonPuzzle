using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolvableObject : InteractableObject
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Collider _collider;

    public override void StartInteracting()
    {
        LeanTween.value(gameObject, -1.4f, 2, 5).setOnUpdate((float value) =>
        {
            _renderer.material.SetFloat("_DissolveAmount", value);
        });
        _collider.enabled = false;
    }

}
