using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _gameObjectsToActivateWhenSolved = new List<GameObject>();
    [SerializeField] private List<GameObject> _gameObjectsToDeactivateWhenSolved = new List<GameObject>();
    [SerializeField] private List<PuzzleSolvedConsequence> _puzzleSolvedConsequences = new List<PuzzleSolvedConsequence>();
    private PuzzleState puzzleState = PuzzleState.NON_COMPLETED;
    private enum PuzzleState
    {
        NON_COMPLETED,
        COMPLETED,
    }

    private void Awake()
    {
        foreach (GameObject gameObject in _gameObjectsToActivateWhenSolved)
        {
            gameObject.SetActive(false);
        }

        foreach (GameObject gameObject in _gameObjectsToDeactivateWhenSolved)
        {
            gameObject.SetActive(true);
        }
    }

    public virtual void PuzzleCompleted() 
    {
        foreach(GameObject gameObject in _gameObjectsToActivateWhenSolved)
        {
            gameObject.SetActive(true);
        }

        foreach (GameObject gameObject in _gameObjectsToDeactivateWhenSolved)
        {
            gameObject.SetActive(false);
        }

        foreach(PuzzleSolvedConsequence puzzleSolvedConsequence in _puzzleSolvedConsequences)
        {
            puzzleSolvedConsequence.InvokeConsequence();
        }
    }
}
