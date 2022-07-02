using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatoryRecipientButton : InteractableObject
{
    [SerializeField] private RotationType _rotationType;
    [SerializeField] private RotatoryRecipient _rotatoryRecipient;
    private enum RotationType
    {
        VERTICAL,
        HORIZONTAL,
    }

    private State _state = State.NON_PRESSED;
    public enum State
    {
        PRESSED,
        NON_PRESSED
    }

    public override void StartInteracting()
    {
        if (_state == State.NON_PRESSED && _rotatoryRecipient.GetRotatoryRecipientState() != RotatoryRecipient.RotatoryRecipientState.ROTATING)
        {
            _state = State.PRESSED;
            _rotatoryRecipient.SetRotatoryRecipientRotating();
            switch (_rotationType)
            {
                case RotationType.VERTICAL:
                    LeanTween.rotateAround(_rotatoryRecipient.GetHorizontalRotator(), new Vector3(0,1,0), 90, 2).setOnComplete(() =>
                    {
                        _rotatoryRecipient.CheckRotation();
                        _state = State.NON_PRESSED;
                    });
                    break;
                case RotationType.HORIZONTAL:
                    LeanTween.rotateAround(_rotatoryRecipient.GetHorizontalRotator(), new Vector3(1, 0, 0), 90, 2).setOnComplete(() =>
                    {
                        _rotatoryRecipient.CheckRotation();
                        _state = State.NON_PRESSED;
                    });
                    break;
            }
        }
    }
}