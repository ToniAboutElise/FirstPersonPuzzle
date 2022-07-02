using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatoryRecipientPuzzleManager : PuzzleManager
{
    [SerializeField] private List<RotatoryRecipient> _rotatoryRecipients = new List<RotatoryRecipient>();
    private void Start()
    {
        foreach(RotatoryRecipient rotatoryRecipient in _rotatoryRecipients)
        {
            rotatoryRecipient.onSetCorrect += CheckAllRecipientState;
        }
    }

    public override void PuzzleCompleted()
    {
        foreach (RotatoryRecipient rotatoryRecipient in _rotatoryRecipients)
        {
            rotatoryRecipient.onSetCorrect -= CheckAllRecipientState;
        }
    }

    public void CheckAllRecipientState()
    {
        foreach (RotatoryRecipient rotatoryRecipient in _rotatoryRecipients)
        {
            if(rotatoryRecipient.GetRotatoryRecipientState() != RotatoryRecipient.RotatoryRecipientState.CORRECT)
            {
                return;
            }
        }

        PuzzleCompleted();

    }
}