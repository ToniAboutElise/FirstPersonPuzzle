using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObjectsManager : PuzzleManager
{
    [SerializeField] private List<SpinningObject> _spinningObjects = new List<SpinningObject>();

    public void CheckAllSpinningObjectsRotationStatus()
    {
        foreach(SpinningObject spinningObject in _spinningObjects)
        {
            if(spinningObject.GetRotationStatus() == SpinningObject.RotationStatus.Incorrect)
            {
                return;
            }
        }
        PuzzleCompleted();
    }

    public override void PuzzleCompleted()
    {
        base.PuzzleCompleted();
        Debug.Log("Completed");
    }
}
