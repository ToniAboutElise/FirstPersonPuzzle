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
        }
        _rubicketteRotationSetterButton.onPress += ChangeRotation;
    }

    public override void PuzzleCompleted()
    {
        base.PuzzleCompleted();

        foreach (RubickettePuzzlePiece rubickettePuzzlePiece in _rubickettePuzzlePieces)
        {
            rubickettePuzzlePiece.onSetCorrect -= CheckAllRecipientState;
            rubickettePuzzlePiece.GetCollider().enabled = false;
        }
        _rubicketteRotationSetterButton.onPress -= ChangeRotation;
        _rubicketteRotationSetterButton.GetCollider().enabled = false;
    }

    private void ChangeRotation()
    {
        foreach (RubickettePuzzlePiece rubickettePuzzlePiece in _rubickettePuzzlePieces)
        {
            switch (rubickettePuzzlePiece.GetRotationType())
            {
                case RubickettePuzzlePiece.RotationType.X:
                    rubickettePuzzlePiece.SetRotationType(RubickettePuzzlePiece.RotationType.Z);
                    break;
                case RubickettePuzzlePiece.RotationType.Z:
                    rubickettePuzzlePiece.SetRotationType(RubickettePuzzlePiece.RotationType.Y);
                    break;
                case RubickettePuzzlePiece.RotationType.Y:
                    rubickettePuzzlePiece.SetRotationType(RubickettePuzzlePiece.RotationType.X);
                    break;
            }
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
