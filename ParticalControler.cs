using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalControler : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private GameObject toxic;

    [SerializeField] private ParticleSystem _particleSystem;
    // Start is called before the first frame update
    async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //gameObject.active = true;
            toxic.active = false;
            _particleSystem.Play();
            //Destroy(toxic);
        }
    }

}
