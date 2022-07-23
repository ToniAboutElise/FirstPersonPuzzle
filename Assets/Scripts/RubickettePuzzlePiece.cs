using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubickettePuzzlePiece : InteractableObject
{
    [SerializeField] private Vector3 _targetLocalEulerAngles;

    public RubickettePuzzlePieceState _rubickettePuzzlePieceState = RubickettePuzzlePieceState.INCORRECT;
    public enum RubickettePuzzlePieceState
    {
        INCORRECT,
        CORRECT,
        ROTATING,
    }

    [SerializeField] private RotationType _rotationType;
    public enum RotationType
    {
        X,
        Y,
        Z,
    }

    private State _state = State.NON_PRESSED;
    public enum State
    {
        PRESSED,
        NON_PRESSED
    }

    public delegate void OnSetCorrect();
    public OnSetCorrect onSetCorrect;

    public RubickettePuzzlePieceState GetRubickettePuzzlePieceState() { return _rubickettePuzzlePieceState; }
    public RotationType GetRotationType() { return _rotationType; }
    public void SetRotationType(RotationType rotationType) { _rotationType = rotationType; }

    public override void StartInteracting()
    {
        if (_state == State.NON_PRESSED)
        {
            _state = State.PRESSED;
            switch (_rotationType)
            {
                case RotationType.X:
                    LeanTween.rotateAround(gameObject, -transform.parent.right, 90, 1).setOnComplete(() =>
                    {
                        //_rotatoryRecipient.CheckRotation();
                        _state = State.NON_PRESSED;
                    });
                    break;
                case RotationType.Y:
                    LeanTween.rotateAround(gameObject, transform.parent.forward, 90, 1).setOnComplete(() =>
                    {
                        //_rotatoryRecipient.CheckRotation();
                        _state = State.NON_PRESSED;
                    });
                    break;
                case RotationType.Z:
                    LeanTween.rotateAround(gameObject, transform.parent.up, 90, 1).setOnComplete(() =>
                    {
                        //_rotatoryRecipient.CheckRotation();
                        _state = State.NON_PRESSED;
                    });
                    break;
            }
        }
    }

    public void CheckRotation()
    {
        if ((int)transform.localEulerAngles.x == (int)_targetLocalEulerAngles.x && (int)transform.localEulerAngles.y == (int)_targetLocalEulerAngles.y && (int)transform.localEulerAngles.z == (int)_targetLocalEulerAngles.z)
        {
            SetCorrect();
        }
        else
        {
            SetIncorrect();
        }
    }

    public void SetCorrect()
    {
        _rubickettePuzzlePieceState = RubickettePuzzlePieceState.CORRECT;
        onSetCorrect.Invoke();
    }

    private void SetIncorrect()
    {
        _rubickettePuzzlePieceState = RubickettePuzzlePieceState.INCORRECT;
    }

}
