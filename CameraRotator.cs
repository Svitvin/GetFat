using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    CinemachineSmoothPath _path;
    CinemachineVirtualCamera _camera;
    CinemachineTrackedDolly _dolly;
    float defaultRotation;


    private void Awake()
    {
        _path = LevelSetup.Path;
        Debug.Log(LevelSetup.Path);
        _camera = GetComponent<CinemachineVirtualCamera>();
        _dolly = _camera.GetCinemachineComponent<CinemachineTrackedDolly>();
        defaultRotation = transform.rotation.eulerAngles.y;
    }

    private void Start()
    {
        //_camera.LookAt = GameObject.Find("Hero").transform;

    }


    void Update()
    {
        float currentRotation = (defaultRotation + _path.EvaluateOrientation(_dolly.m_PathPosition).eulerAngles.y);  
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, currentRotation, -20), 0.5f);
    }
}
