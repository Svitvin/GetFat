using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [SerializeField] List<Rigidbody> rigidbodies;
    /*void Start()
    {
        for (int i = 0; i < rigidbodies.Count; i++)
        {
            rigidbodies[i].isKinematic = true;
        }
    }*/

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("RagdollPuncher"))
        {
            EnableRagdoll();
        }
    }*/

    /*void EnableRagdoll()
    {
        for (int i = 0; i < rigidbodies.Count; i++) rigidbodies[i].isKinematic = false;
    }*/

    public void Punch()
    {
        GetComponentInParent<RunningEnemy>().collided = true;
        rigidbodies[0].AddForce(-transform.forward * 10, ForceMode.Impulse);
        rigidbodies[1].AddForce(-transform.forward * 10, ForceMode.Impulse);
        rigidbodies[2].AddForce(-transform.forward * 5, ForceMode.Impulse);
        rigidbodies[3].AddForce(-transform.forward * 5, ForceMode.Impulse);
        rigidbodies[4].AddForce(-transform.forward * 5, ForceMode.Impulse);
        rigidbodies[5].AddForce(-transform.forward * 5, ForceMode.Impulse);
        rigidbodies[6].AddForce(-transform.forward * 5, ForceMode.Impulse);
        rigidbodies[7].AddForce(-transform.forward * 5, ForceMode.Impulse);
        rigidbodies[8].AddForce(-transform.forward * 5, ForceMode.Impulse);
        rigidbodies[9].AddForce(-transform.forward * 5, ForceMode.Impulse);
        rigidbodies[10].AddForce(-transform.forward * 10, ForceMode.Impulse);
        
    }
}
