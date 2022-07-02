using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatoryRecipient : MonoBehaviour
{
    [SerializeField] private GameObject _verticalRotator;
    [SerializeField] private GameObject _horizontalRotator;
    [SerializeField] private Vector3 targetVertical;
    [SerializeField] private Vector3 targetHorizontal;
    private RotatoryRecipientState _rotatoryRecipientState = RotatoryRecipientState.INCORRECT;
    public enum RotatoryRecipientState
    {
        INCORRECT,
        CORRECT,
        ROTATING,
    }

    public GameObject GetVerticalRotator() { return _verticalRotator; }
    public GameObject GetHorizontalRotator() { return _horizontalRotator; }

    public void SetRotatoryRecipientRotating() { _rotatoryRecipientState = RotatoryRecipientState.ROTATING; }
    public RotatoryRecipientState GetRotatoryRecipientState() { return _rotatoryRecipientState; }

    public delegate void OnSetCorrect();
    public OnSetCorrect onSetCorrect;

    public void CheckRotation()
    {
        if (_verticalRotator.transform.localEulerAngles == targetVertical && _horizontalRotator.transform.localEulerAngles == targetHorizontal)
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
        _rotatoryRecipientState = RotatoryRecipientState.CORRECT;
        onSetCorrect.Invoke();
    }

    private void SetIncorrect()
    {
        _rotatoryRecipientState = RotatoryRecipientState.INCORRECT;
    }
}