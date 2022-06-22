using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpinningObject : InteractableObject
{
    [SerializeField] private AxisToCheck _axisToCheck;
    [SerializeField] private float _degreesToRotateX = 0;
    [SerializeField] private float _degreesToRotateY = 0;
    [SerializeField] private float _degreesToRotateZ = 0;
    [SerializeField] private Vector3 _correctLocalEulerAngles;
    public Vector3 currentEulerAngles;
    
    public enum AxisToCheck
    {
        X,
        Y,
        Z,
    }
    [SerializeField] private RotationStatus _rotationStatus;
    public enum RotationStatus
    {
        Correct,
        Incorrect
    }

    public Vector3 GetCorrectLocalEulerAngles() { return transform.localEulerAngles; }

    public RotationStatus GetRotationStatus() { return _rotationStatus; }

    private void Start()
    {
        CheckRotationStatus();
    }

    public override void StartInteracting()
    {
        if(Player.instance.GetInteractionStatus() != Player.InteractionStatus.INTERACTING)
        {
            Player.instance.SetInteractionStatus(Player.InteractionStatus.INTERACTING);

            LTDescr rotate = LeanTween.rotateLocal(gameObject, transform.localEulerAngles + new Vector3(_degreesToRotateX, _degreesToRotateY, _degreesToRotateZ), 15 * Time.deltaTime);
            rotate.setOnComplete(() => {
                Player.instance.SetInteractionStatus(Player.InteractionStatus.NOT_INTERACTING);
                CheckRotationStatus();
                currentEulerAngles = transform.localEulerAngles;
            });
        }
    }

    private void CheckRotationStatus()
    {
        float _objectValue = -1;
        float _targetValue = -2;
        switch (_axisToCheck)
        {
            case AxisToCheck.X:
                _objectValue = transform.localEulerAngles.x;
                _targetValue = _correctLocalEulerAngles.x;
                break;
            case AxisToCheck.Y:
                _objectValue = transform.localEulerAngles.y;
                _targetValue = _correctLocalEulerAngles.y;
                break;
            case AxisToCheck.Z:
                _objectValue = transform.localEulerAngles.z;
                _targetValue = _correctLocalEulerAngles.z;
                break;
        }

        //Correction due to local euler angles having issues with exact zero value
        if (_objectValue > 0 && _objectValue < 10)
        {
            _objectValue = 0;
            Debug.Log(_objectValue + " " + _targetValue);
        }

        if ((int)_objectValue == (int)_targetValue)
        {
            _rotationStatus = RotationStatus.Correct;
            Debug.Log("Correct");
            transform.parent.GetComponent<SpinningObjectsManager>().CheckAllSpinningObjectsRotationStatus();
        }
        else
        {
            _rotationStatus = RotationStatus.Incorrect;
        }
    }
}
