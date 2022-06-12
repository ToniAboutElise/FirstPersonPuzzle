using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialObject : InteractableObject
{
    private State _state = State.NonPressed;
    public enum State
    {
        Pressed,
        NonPressed
    }

    public State GetState() { return _state; }

    public override void StartInteracting()
    {
        if (_state == State.NonPressed)
        {
            _state = State.Pressed;
            transform.parent.GetComponent<SequentialObjectsManager>().SequentialObjectWasPressed(this);
        }
    }

    public void ResetToNonPressed()
    {
        
    }
}
