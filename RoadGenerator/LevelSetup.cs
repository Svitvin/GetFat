using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.PlayerLoop;

public class LevelSetup : MonoBehaviour
{
    [Header("������ ����� ���������� � ���������� ������.")]
    int _roadLength;
    [Space]
    [Header("Prefab")]
    [SerializeField] RoadSection _start;
    [SerializeField] RoadSection[] _roadSections;
    [SerializeField] RoadSection _finish;
    [Header("���� ��������� ������ (����� ������ - ����� ������� � RoadSections. ���� - �����������).")]
    [SerializeField] float[] _roadChances;
    [Header("Game object")]
    [SerializeField] GameObject _startObject;
    [SerializeField] GameObject[] _gameObject;
    [SerializeField] GameObject _finishObject;
    private List<GameObject> _gameObjects;

    public List<GameObject> GameObjects
    {
        get => _gameObjects;
        set => _gameObjects = value;
    }

     
    static public CinemachineSmoothPath Path 
    {
        get
        {
            return GameObject.Find("DollyTrack1").GetComponent<CinemachineSmoothPath>(); 
            
        } 
    } 
    public static int cameraPointsCounter = 0;

    private void Start()
    {
        cameraPointsCounter = 0;
        int temp = 2;
        for (int i = 0; i < _roadSections.Length; i++)
        {
            if (_roadSections[i].name == "Round22.5")
            {
                temp++;
            }
        }
        _roadLength = _roadSections.Length;
        Path.m_Waypoints = new CinemachineSmoothPath.Waypoint[_roadLength+temp + 0];
        RoadGenerationSystem.GenerateRoad(_roadLength, _start, _roadSections, _finish, _roadChances, _startObject,_gameObject, _finishObject);
        
    }

    public static void AddCameraPoint(Vector3 point)
    {
        Debug.Log("+");
        Path.m_Waypoints[cameraPointsCounter] = new CinemachineSmoothPath.Waypoint();
        Path.m_Waypoints[cameraPointsCounter].position = point;
        cameraPointsCounter++;
        Path.InvalidateDistanceCache();
    }
}
