using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] protected GameObject _interactableObject;
    public virtual void StartInteracting()
    {

    }

    public virtual void StopInteracting()
    {

    }
}
