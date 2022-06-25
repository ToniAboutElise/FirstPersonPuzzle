using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] private Transform _lookableTransform;
    private PlayerInputActions _playerInputActions;
    private InteractableObject _currentInteractableObject;

    private InteractionStatus _interactionStatus = InteractionStatus.NOT_INTERACTING;
    public enum InteractionStatus
    {
        INTERACTING,
        NOT_INTERACTING
    }

    private BackButtonStatus _backButtonStatus = BackButtonStatus.NON_PRESSED;

    public enum BackButtonStatus
    {
        PRESSED,
        NON_PRESSED
    }

    private InteractionButtonStatus _interactionButtonStatus = InteractionButtonStatus.NON_PRESSED;

    public enum InteractionButtonStatus
    {
        PRESSED,
        NON_PRESSED
    }

    public Transform GetLookableTransform() { return _lookableTransform; }
    public PlayerInputActions GetPlayerInputActions() { return _playerInputActions; }
    public InteractionButtonStatus GetInteractionButtonStatus() { return _interactionButtonStatus; }
    public BackButtonStatus GetBackButtonStatus() { return _backButtonStatus; }
    public InteractionStatus GetInteractionStatus() { return _interactionStatus; }
    public InteractableObject GetCurrentInteractableObject() { return _currentInteractableObject; }
    public void SetInteractionStatus(InteractionStatus interactionStatus) { _interactionStatus = interactionStatus; }
    public void SetCurrentInteractableObject(InteractableObject currentInteractableObject) { _currentInteractableObject = currentInteractableObject; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
    }

    private void InteractionInputManagement()
    {
        if(_playerInputActions.Player.FaceButtonDown.ReadValue<float>() > 0.8f)
        {
            _interactionButtonStatus = InteractionButtonStatus.PRESSED;
        }
        else
        {
            _interactionButtonStatus = InteractionButtonStatus.NON_PRESSED;
        }

        if (_playerInputActions.Player.FaceButtonEast.ReadValue<float>() > 0.8f)
        {
            _backButtonStatus = BackButtonStatus.PRESSED;
        }
        else
        {
            _backButtonStatus = BackButtonStatus.NON_PRESSED;
        }
    }

    private void CheckStopInteracting()
    {
    if (_currentInteractableObject != null && GetBackButtonStatus() == BackButtonStatus.PRESSED && GetInteractionStatus() == InteractionStatus.INTERACTING)
        {
            _currentInteractableObject.StopInteracting();
        }
    }

    private void CurrentObjectInteraction()
    {
        if(_currentInteractableObject != null)
        {
            _currentInteractableObject.WhileInteracting();
        }
    }

    private void FixedUpdate()
    {
        InteractionInputManagement();
        CurrentObjectInteraction();
        CheckStopInteracting();
    }
}
