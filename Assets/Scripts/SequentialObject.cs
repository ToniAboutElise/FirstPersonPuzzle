using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialObject : InteractableObject
{
    [SerializeField] private Color _lightUpColorColor;
    [SerializeField] private Color _disabledColor = new Color(0,0,0,0);
    private State _state = State.NonPressed;
    public enum State
    {
        Pressed,
        NonPressed
    }

    public State GetState() { return _state; }

    private void Start()
    {
        GetComponent<Renderer>().material.color = _disabledColor;
    }

    public override void StartInteracting()
    {
        if (_state == State.NonPressed)
        {
            _state = State.Pressed;
            transform.parent.GetComponent<SequentialObjectsManager>().SequentialObjectWasPressed(this);
            
            LeanTween.color(gameObject, _lightUpColorColor, 0.5f).setOnComplete(() =>
            {
                LeanTween.color(gameObject, _disabledColor, 0.5f).setOnComplete(() =>
                {
                    _state = State.NonPressed;
                });
            });
        }
    }

    public void ResetToNonPressed()
    {
        
    }
}
