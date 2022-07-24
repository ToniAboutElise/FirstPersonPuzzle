using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallIconsManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleManager> _targetPuzzles = new List<PuzzleManager>();
    [SerializeField] private GameObject _objectToDeactivateWhenCompleted;
    [SerializeField] private GameObject _objectToActivateWhenCompleted;
    private int _currentPuzzlesSolved = 0;

    private void Awake()
    {
        foreach(PuzzleManager puzzleManager in _targetPuzzles)
        {
            puzzleManager.onPuzzleCompleted += PuzzleWasCompleted;
        }
    }

    private void PuzzleWasCompleted()
    {
        _currentPuzzlesSolved++;

        if(_currentPuzzlesSolved == _targetPuzzles.Count)
        {
            AllRequiredPuzzlesCompleted();
        }
    }

    private void AllRequiredPuzzlesCompleted()
    {
        foreach (PuzzleManager puzzleManager in _targetPuzzles)
        {
            puzzleManager.onPuzzleCompleted -= PuzzleWasCompleted;
        }

        _objectToDeactivateWhenCompleted.SetActive(false);
        _objectToActivateWhenCompleted.SetActive(true);
    }
}
