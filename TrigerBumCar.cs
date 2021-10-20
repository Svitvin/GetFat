using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerBumCar : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private GameObject[] Car;
    //[SerializeField] private GameObject[] CarRig;

    [SerializeField] private ParticleSystem[] _particleSystem;
    // Start is called before the first frame update
    async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(_particleSystem.Length);
            for (int i = 0; i < _particleSystem.Length; i++)
            {
                Debug.Log("BUM");
                _particleSystem[i].Play();
            }
        }
    }
}
