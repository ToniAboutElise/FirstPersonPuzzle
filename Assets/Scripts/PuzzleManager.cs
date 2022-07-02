using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private PuzzleState puzzleState = PuzzleState.NON_COMPLETED;
    private enum PuzzleState
    {
        NON_COMPLETED,
        COMPLETED,
    }

    public virtual void PuzzleCompleted() { }
}
