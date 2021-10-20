using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraPoint : RoadObjectPoint
{
    public override void SetEntity()
    {
        LevelSetup.AddCameraPoint(transform.position);
        //Destroy(gameObject);
    }
}
