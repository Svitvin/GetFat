using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WallTriger : MonoBehaviour
{
    [SerializeField] GameObject colbaObGameObject;
    [SerializeField] Rigidbody colbaObject;
    [SerializeField] private Vector3 speedColb;
    [SerializeField] private Transform _transformDoctorVoli;
    [SerializeField] private Transform _transform;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            colbaObGameObject.active = true;
            colbaObject.isKinematic = false;
            float minX = 0.2f;
            float maxX = 1.2f;
            float x = 0.7f;
            float minZ = 0f;
            float maxZ = 0f;
            float z = 0f;
            float temp = 0.7f / 90f;
            float tempMax = 0.7f / 90f;
            if (_transform.rotation.y != 0)
            {
                Quaternion q = _transform.rotation.normalized;
                Vector3 vector3 = q.eulerAngles;
                if (vector3.y > 2)
                {
                    
                }
                float f = 360 - Math.Abs(vector3.y);
                x = 0.7f - (temp * f );
                maxX = 1.2f - (tempMax * f);
                z = (temp * f);
                maxZ = (tempMax * f);
            }
            colbaObject.AddForce(new Vector3(x + Random.Range(minX, maxX) , 0,z + Random.Range(minZ, maxZ)), ForceMode.VelocityChange);
        }
    }
}
