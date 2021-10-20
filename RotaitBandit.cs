using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaitBandit : MonoBehaviour
{ 
    private HeroMovement _heroMovement;
    [SerializeField] private GameObject _gameObject;
    void Awake()
    {
        _heroMovement = GameObject.Find("Hero").GetComponent<HeroMovement>();
    }

    void Update()
    {
        float angle = _heroMovement.TargetPosition;
            
        //Debug.Log(_gameObject.transform.rotation.y);
        //_gameObject.transform.rotation = new Quaternion(_gameObject.transform.rotation.x,_gameObject.transform.rotation.y,_gameObject.transform.rotation.z,_gameObject.transform.rotation.w);
    }
}
