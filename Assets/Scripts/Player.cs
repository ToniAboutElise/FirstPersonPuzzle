using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] private Transform _lookableTransform;

    public Transform GetLookableTransform() { return _lookableTransform; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
