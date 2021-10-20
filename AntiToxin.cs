using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiToxin : MonoBehaviour
{
    [SerializeField] GameObject colba;
    [SerializeField] GameObject toxin;
    [SerializeField] GameObject toxinMat;
    [SerializeField] GameObject colbaObGameObject;
    [SerializeField] Rigidbody colbaObject;
    [SerializeField] private Vector3 speedColb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MoveColbe"))
        {
            
            colbaObGameObject.active = true;
            colbaObject.isKinematic = false;
            colbaObject.AddForce(speedColb, ForceMode.VelocityChange);
        }
        else if (other.CompareTag("Floor"))
        {
            colba.active = false;
            toxin.active = false;
            toxinMat.active = true;
            GetComponent<Collider>().enabled = false;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
