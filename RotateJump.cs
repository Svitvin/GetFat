    using System;
    using System.Collections;
using System.Collections.Generic;
    using System.Threading.Tasks;
    using UnityEngine;

public class RotateJump : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    private bool temp = false;
    private async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            await Task.Delay(200);
            temp = true;
        }
    }

    private async void Update()
    {
        if (temp)
        {

            _gameObject.transform.Rotate((new Vector3(80f, 0, 0) * Time.deltaTime));
            if (_gameObject.transform.rotation.x >= 0.1f)
            {
                _gameObject.transform.Rotate((new Vector3(-10, 0, 0) ));
                temp = false;
            }

        }
    }
}
