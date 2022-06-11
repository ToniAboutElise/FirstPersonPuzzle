using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeJointLookableObject : LookableObject
{
    [SerializeField] private Rigidbody _hingeJointRigidbody;
    [SerializeField] private Vector3 _originalLocalPosition;
    [SerializeField] private Quaternion _originalLocalRotation;

    public override void StartInteracting()
    {
        _originalLocalRotation = _hingeJointRigidbody.transform.localRotation;
        _originalLocalPosition = _hingeJointRigidbody.transform.localPosition;

        base.StartInteracting();

        _hingeJointRigidbody.isKinematic = false;
        _hingeJointRigidbody.useGravity = true;
    }

    public override void StopInteracting()
    {
        _hingeJointRigidbody.transform.localRotation = _originalLocalRotation;
        _hingeJointRigidbody.transform.localPosition = _originalLocalPosition;

        base.StopInteracting();

        _hingeJointRigidbody.isKinematic = true;
        _hingeJointRigidbody.useGravity = false;
    }
}
