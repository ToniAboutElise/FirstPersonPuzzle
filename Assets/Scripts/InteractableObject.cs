using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] protected GameObject _interactableObject;
    public virtual void StartInteracting()
    {
        FirstPersonController.instance.SetCanMoveAndJump(false);
    }

    public virtual void StopInteracting()
    {
        FirstPersonController.instance.SetCanMoveAndJump(true);
    }
}
