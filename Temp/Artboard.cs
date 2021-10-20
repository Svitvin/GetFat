using System;
using UnityEngine;

[Serializable]
public class Artboard
{
    [Space]
    [SerializeField]
    Vector3 startBoundary;
    public Vector3 StartBoundary
    {
        get
        {
            return startBoundary;
        }
    }

    [Space]
    [SerializeField]
    Vector3 endBoundary;
    public Vector3 EndBoundary
    {
        get
        {
            return endBoundary;
        }
    }
}
