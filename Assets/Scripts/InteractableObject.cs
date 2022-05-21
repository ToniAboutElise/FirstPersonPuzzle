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
        Player.instance.SetInteractionStatus(Player.InteractionStatus.INTERACTING);
        Player.instance.SetCurrentInteractableObject(this);
    }

    public virtual void StopInteracting()
    {
        FirstPersonController.instance.SetCanMoveAndJump(true);
        Player.instance.SetInteractionStatus(Player.InteractionStatus.NOT_INTERACTING);
        Player.instance.SetCurrentInteractableObject(null);
    }
}
