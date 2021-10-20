
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ObjectUpdater : MonoBehaviour
{
    RoadObjectPoint _point;

    private void Start()
    {
        _point = GetComponent<RoadObjectPoint>();
        if (Application.IsPlaying(this))
        {
            Destroy(this);
        }
    }

    void Update()
    {
        _point.Position = transform.localPosition.x + 0.5f;
    }
}


