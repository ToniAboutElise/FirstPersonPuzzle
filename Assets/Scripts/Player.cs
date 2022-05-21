using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player
{
    [SerializeField] private static Transform _lookableTransform;

    public static Transform GetLookableTransform() { return _lookableTransform; }


}
