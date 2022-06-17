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

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1.3f, layerMask))
        {
            _raycastColor = Color.red;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, _raycastColor);

            if (hit.transform.gameObject.GetComponent<InteractableObject>() && Player.instance.GetInteractionStatus() == Player.InteractionStatus.NOT_INTERACTING)
            {
                _raycastColor = Color.blue;
                UIManager.instance.SetInteractiveImageActive(true);
                
                if(Player.instance.GetCurrentInteractableObject() == null && Player.instance.GetInteractionButtonStatus() == Player.InteractionButtonStatus.PRESSED && Player.instance.GetInteractionStatus() == Player.InteractionStatus.NOT_INTERACTING) 
                { 
                    hit.transform.gameObject.GetComponent<InteractableObject>().StartInteracting();
                    UIManager.instance.SetInteractiveImageActive(false);
                }
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1, _raycastColor);
            UIManager.instance.SetInteractiveImageActive(false);
        }
    }
}
