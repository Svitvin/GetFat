using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class UnActiveObject : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjects;
    private async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < _gameObjects.Length; i++)
            {
                _gameObjects[i].active = false;
            }
        }
    }
}
