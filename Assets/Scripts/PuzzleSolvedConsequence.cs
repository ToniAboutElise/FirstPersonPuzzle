using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSolvedConsequence : MonoBehaviour
{
    [SerializeField] private ConsequenceType _consequenceType = ConsequenceType.MOVE;
    [SerializeField] private GameObject _affectedGameObject;
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private float _time;
    private enum ConsequenceType
    {
        MOVE,
    }

    public void InvokeConsequence()
    {
        switch (_consequenceType)
        {
            case ConsequenceType.MOVE:
                LTDescr move = LeanTween.moveLocal(_affectedGameObject, _targetPosition, _time);
                break;
        }
    }
}
