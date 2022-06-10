using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObject : InteractableObject
{
    [SerializeField] private float _degreesToRotateX = 0;
    [SerializeField] private float _degreesToRotateY = 0;
    [SerializeField] private float _degreesToRotateZ = 0;
    [SerializeField] private Vector3 _correctLocalEulerAngles;

    private RotationStatus _rotationStatus;
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
            });
        }
    }

    private void CheckRotationStatus()
    {
        if (transform.localEulerAngles == _correctLocalEulerAngles)
        {
            _rotationStatus = RotationStatus.Correct;
            transform.parent.GetComponent<SpinningObjectsManager>().CheckAllSpinningObjectsRotationStatus();
        }
        else
        {
            _rotationStatus = RotationStatus.Incorrect;
        }
    }
}
