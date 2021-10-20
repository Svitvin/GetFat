using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject _transformHero;
    [SerializeField] private GameObject _transformHips;
    [SerializeField] private HeroMovement _heroMovement;
    [SerializeField] private GameObject _gameObjectsPrefab;

    [SerializeField] private ParticleSystem _particalControler;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            if (_heroMovement.IsAgresionJamping)
            {
                Transform copy =  Instantiate(_gameObjectsPrefab.transform, new Vector3(_transformHero.transform.position.x, 0.01f, _transformHero.transform.position.z),quaternion.identity);
                Destroy(copy.gameObject,1f);
            }
        }
    }
}
