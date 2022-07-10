using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatoryRecipientPuzzleManager : PuzzleManager
{
    [SerializeField] private List<RotatoryRecipient> _rotatoryRecipients = new List<RotatoryRecipient>();
    [SerializeField] private List<RotatoryRecipientButton> _rotatoryRecipientButtons = new List<RotatoryRecipientButton>();
    private void Start()
    {
        foreach(RotatoryRecipient rotatoryRecipient in _rotatoryRecipients)
        {
            rotatoryRecipient.onSetCorrect += CheckAllRecipientState;
        }
    }

    public override void PuzzleCompleted()
    {
        base.PuzzleCompleted();

        foreach (RotatoryRecipientButton rotatoryRecipientButton in _rotatoryRecipientButtons)
        {
            rotatoryRecipientButton.GetCollider().enabled = false;
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