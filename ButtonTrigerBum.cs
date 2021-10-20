using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigerBum : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool temp = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            temp = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (temp)
        {
            _gameObject.transform.position = (new Vector3(_gameObject.transform.position.x,
                _gameObject.transform.position.y + (-0.03f * Time.deltaTime), _gameObject.transform.position.z));
        }
    }
}
    