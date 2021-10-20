using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RoadObjectPoint : MonoBehaviour
{
    public float Position { get; set; }
    public abstract void SetEntity();
}

