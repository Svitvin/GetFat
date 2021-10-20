using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.Rendering;
using UnityEngine;

public class SpecularAlbedo : MonoBehaviour
{

    [SerializeField] private Material _material;
    [SerializeField] private GameObject _gameObject;
    private void Start()
    {
        _material.color = new Color(1,1,1,1);
    }
    private async void OnTriggerEnter(Collider other)
    {
        await Task.Delay(400);
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 100; i > 0; i--)
            {
                _material.color = new Color(1,1,1,i/100f);
                Debug.Log(_material.color.a);
                await Task.Delay(1);
            }
            _gameObject.active = false;
        }
    }
}
