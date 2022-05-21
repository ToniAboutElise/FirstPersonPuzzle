using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookableObject : InteractableObject
{
    public override void StartInteracting()
    {
        base.StartInteracting();
        //Player.GetLookableTransform()
    }

    public override void StopInteracting()
    {
        base.StopInteracting();
    }
}
