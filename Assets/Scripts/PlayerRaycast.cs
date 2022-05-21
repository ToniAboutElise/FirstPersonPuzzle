using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    private Color _raycastColor;

    private void FixedUpdate()
    {
        Raycast();
    }

    private void Raycast()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1.8f, layerMask))
        {
            _raycastColor = Color.red;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, _raycastColor);

            if (hit.transform.gameObject.GetComponent<InteractableObject>())
            {
                _raycastColor = Color.blue;
                hit.transform.gameObject.GetComponent<InteractableObject>().StartInteracting();
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1, _raycastColor);
            Debug.Log("Did not Hit");
        }
    }
}
