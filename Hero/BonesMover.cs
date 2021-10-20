using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonesMover : MonoBehaviour
{
    [SerializeField] AnimationCurve updownMove;
    [SerializeField] FatnessController fc;

    void Update()
    {
        transform.position = transform.position + Vector3.up * updownMove.Evaluate(Time.time*3) * 4 ;
    }
}
