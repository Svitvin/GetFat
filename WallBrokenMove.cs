using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class WallBrokenMove : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    
    [SerializeField] private Rigidbody[] _rigidbodies;

    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private BoxCollider _boxCollider2;

    [SerializeField] private Vector3 Vector3Max;
    [SerializeField] private Vector3 Vector3Min;

    [SerializeField] private String hero;
    [SerializeField] private String enemy;

    [SerializeField] private bool temp;

    private HeroMovement _heroMovement;

    void Awake()
    {
        _heroMovement = GameObject.Find("Hero").GetComponent<HeroMovement>();
    }

    private async void OnTriggerEnter(Collider other)
    {
        float mnozutel = 0;
        if (_heroMovement.IsAgresionJamping)
        {
            mnozutel = 2;
        }
        Debug.Log(mnozutel);
        if (other.gameObject.CompareTag(enemy))
        {
            Vector3 vector3 = new Vector3(0, 0, 0);
            if (temp)
            {
                for (int i = 0; i < _rigidbodies.Length; i++)
                {
                    int x = -1;
                    int z = -1;
                    if (i%2 == 0)
                    {
                        x = 1;
                        z = 1;
                    }
                    float xMove = Random.Range(Vector3Min.x, Vector3Max.x) * x;
                    float yMove = Random.Range(Vector3Min.y + mnozutel, Vector3Max.y - mnozutel-1);
                    float zMove = Random.Range(Vector3Min.z, Vector3Max.z) * z;
                    vector3 = new Vector3(xMove,yMove,zMove);
                    _rigidbodies[i].AddForce(vector3, ForceMode.Impulse);
                    _boxCollider.enabled = false;
                    _boxCollider2.enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < _rigidbodies.Length; i++)
                {
                    float xMove = Random.Range(Vector3Min.x, Vector3Max.x);
                    float yMove = Random.Range(Vector3Min.y + mnozutel/25, Vector3Max.y );
                    float zMove = Random.Range(Vector3Min.z, Vector3Max.z);
                    vector3 = new Vector3(xMove * mnozutel,yMove * mnozutel,zMove * mnozutel);
                    _rigidbodies[i].AddForce(vector3, ForceMode.Impulse);
                    _boxCollider.enabled = false;
                    _boxCollider2.enabled = false;
                }
            }
        }
        else if (other.gameObject.CompareTag(hero))
        {
            Vector3 vector3 = new Vector3(0, 0, 0);
            if (temp)
            {
                for (int i = 0; i < _rigidbodies.Length; i++)
                {
                    int x = Random.Range(-1, 1);
                    int z = Random.Range(-1, 1);
                    float xMove = Random.Range(Vector3Min.x, Vector3Max.x) * x;
                    float yMove = Random.Range(Vector3Min.y + mnozutel, Vector3Max.y - mnozutel-1);
                    float zMove = Random.Range(Vector3Min.z, Vector3Max.z) * z;
                    vector3 = new Vector3(xMove,yMove,zMove);
                    _rigidbodies[i].AddForce(vector3*mnozutel, ForceMode.Impulse);
                    _boxCollider.enabled = false;
                    _boxCollider2.enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < _rigidbodies.Length; i++)
                {
                    float xMove = Random.Range(Vector3Min.x, Vector3Max.x);
                    float yMove = Random.Range(Vector3Min.y + mnozutel, Vector3Max.y - mnozutel-1);
                    float zMove = Random.Range(Vector3Min.z, Vector3Max.z);
                    vector3 = new Vector3(xMove,yMove,zMove);
                    _rigidbodies[i].AddForce(vector3*mnozutel, ForceMode.Impulse);
                    _boxCollider.enabled = false;
                    _boxCollider2.enabled = false;
                }
            }
            await Task.Delay(1000);
            Debug.Log("activ");
            this.gameObject.active = false;
        }
    }
}
