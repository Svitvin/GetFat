using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSection : MonoBehaviour
{
    [SerializeField] GameObject[] _onRoadStructuresPrefabs;
    public int _length = 3;
    [SerializeField] float[] _chances;
    public GameObject _gameObject;
    public Transform endPoint;

    private void Start()
    {
        
        if (_onRoadStructuresPrefabs.Length > 0)
        {
            Instantiate(_gameObject, new Vector3(transform.position.x,transform.position.y,transform.position.z) , transform.rotation, this.transform ).GetComponent<OnRoadStructure>();
        }
    }
}
