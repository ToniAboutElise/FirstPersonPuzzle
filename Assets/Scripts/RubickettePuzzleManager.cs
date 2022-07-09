using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubickettePuzzleManager : PuzzleManager
{
    [SerializeField] private List<RubickettePuzzlePiece> _rubickettePuzzlePieces = new List<RubickettePuzzlePiece>();
    [SerializeField] private RubicketteRotationSetterButton _rubicketteRotationSetterButton;
    private void Start()
    {
        foreach (RubickettePuzzlePiece rubickettePuzzlePiece in _rubickettePuzzlePieces)
        {
            rubickettePuzzlePiece.onSetCorrect += CheckAllRecipientState;
            _rubicketteRotationSetterButton.onPress += ChangeRotation;
        }
    }

    public override void PuzzleCompleted()
    {
        foreach (RubickettePuzzlePiece rubickettePuzzlePiece in _rubickettePuzzlePieces)
        {
            rubickettePuzzlePiece.onSetCorrect -= CheckAllRecipientState;
            _rubicketteRotationSetterButton.onPress -= ChangeRotation;
        }
    }

    private void ChangeRotation()
    {
        foreach (RubickettePuzzlePiece rubickettePuzzlePiece in _rubickettePuzzlePieces)
        {
            if (rubickettePuzzlePiece.GetRotationType() == RubickettePuzzlePiece.RotationType.HORIZONTAL)
                rubickettePuzzlePiece.SetRotationType(RubickettePuzzlePiece.RotationType.VERTICAL);
            else
                rubickettePuzzlePiece.SetRotationType(RubickettePuzzlePiece.RotationType.HORIZONTAL);
        }
    }

    public void CheckAllRecipientState()
    {
        foreach (RubickettePuzzlePiece rubickettePuzzlePiece in _rubickettePuzzlePieces)
        {
            if (rubickettePuzzlePiece.GetRubickettePuzzlePieceState() != RubickettePuzzlePiece.RubickettePuzzlePieceState.CORRECT)
            {
                return;
            }
        }
        PuzzleCompleted();
    }
}
