using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class RoadGenerationSystem
{
   public static Vector3 _nextRoadSectionPosition = new Vector3(0, 0, 0);
    static public void GenerateRoad(int _roadLength,  RoadSection _start, RoadSection[] _roadSections, RoadSection _finish, float[] _roadChances, GameObject _startObject, GameObject[] _gameObject, GameObject _finishObject)
    {
        Transform road = GameObject.Find("Road").transform;

        
        Quaternion _nextRoadSectionRotation = Quaternion.identity;
        RoadSection currentSection =  SetRoadSection(_start, _nextRoadSectionPosition, _nextRoadSectionRotation, road, _startObject);
        
        for (int i = 0; i<_roadLength; i++)
        {
            //Level build
            int randomSectionNumber = i;
            currentSection = SetRoadSection(_roadSections[randomSectionNumber], currentSection.endPoint.position, currentSection.endPoint.rotation, road,_gameObject[i]);
        }

        SetRoadSection(_finish, currentSection.endPoint.position, currentSection.endPoint.rotation, road,_finishObject);
    }

    static RoadSection SetRoadSection(RoadSection section, Vector3 position, Quaternion rotation, Transform parent, GameObject gameObject)
    {
        GameObject go = GameObject.Instantiate(section.gameObject, position, rotation, parent);
        section = go.GetComponent<RoadSection>();
        section._gameObject = gameObject;
        return section;
    }
}
