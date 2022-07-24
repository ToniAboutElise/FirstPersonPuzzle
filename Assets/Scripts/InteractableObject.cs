using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [Header("Leave Interactable object null if you want it to be this GameObject")]
    [SerializeField] protected GameObject _interactableObject;
    protected Collider _collider;

    public Collider GetCollider() { return _collider; }

    protected InteractableState _interactableState = InteractableState.INTERACTABLE;
    public enum InteractableState
    {
        INTERACTABLE,
        NON_INTERACTABLE,
    }

    private void Awake()
    {
        if(_interactableObject == null)
        _interactableObject = gameObject;

        _collider = GetComponent<Collider>();
    }
    public virtual void StartInteracting()
    {
        if(_interactableState == InteractableState.INTERACTABLE) 
        { 
            FirstPersonController.instance.SetCanMoveAndJump(false);
            Player.instance.SetInteractionStatus(Player.InteractionStatus.INTERACTING);
            Player.instance.SetCurrentInteractableObject(this);
        }
    }

    public virtual void StopInteracting()
    {
        FirstPersonController.instance.SetCanMoveAndJump(true);
        Player.instance.SetInteractionStatus(Player.InteractionStatus.NOT_INTERACTING);
        Player.instance.SetCurrentInteractableObject(null);
    }

    public virtual void WhileInteracting()
    {

    }
}
