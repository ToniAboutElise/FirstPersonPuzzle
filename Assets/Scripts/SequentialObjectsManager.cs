using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialObjectsManager : PuzzleManager
{
    [SerializeField] private List<SequentialObject> _sequentialObjectsInCorrectOrder = new List<SequentialObject>();
    [SerializeField] private List<SequentialObject> _currentSequentialObjectsOrder = new List<SequentialObject>();

    private void Update()
    {
        if(_currentSequentialObjectsOrder.Count > 0 && Vector3.Distance(Player.instance.transform.position, transform.position) > 1.7f)
        {
            ResetPuzzle();
        }
    }

    public override void PuzzleCompleted()
    {
        base.PuzzleCompleted();
        Debug.Log("Completed");
    }

    private void ResetPuzzle()
    {
        foreach(SequentialObject sequentialObject in _currentSequentialObjectsOrder)
        {
            sequentialObject.ResetToNonPressed();
        }
        _currentSequentialObjectsOrder.Clear();
    }

    public void SequentialObjectWasPressed(SequentialObject sequentialObject)
    {
        _currentSequentialObjectsOrder.Add(sequentialObject);
        if(_currentSequentialObjectsOrder.Count == _sequentialObjectsInCorrectOrder.Count)
        {
            CheckIfSequenceIsCorrect();
        }
    }

    private void CheckIfSequenceIsCorrect()
    {
        for(int i = 0; i < _sequentialObjectsInCorrectOrder.Count; i++)
        {
            if(_sequentialObjectsInCorrectOrder[i] != _currentSequentialObjectsOrder[i])
            {
                ResetPuzzle();
                return;
            }
        }
        PuzzleCompleted();
    }
}
