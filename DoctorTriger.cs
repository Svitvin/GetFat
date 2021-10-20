using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorTriger : MonoBehaviour
{
    [SerializeField] private Animator doctorAnimator;

    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private Transform position;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {

            //_rigidbody.useGravity = true;
            doctorAnimator.SetBool("MoveColba", true);
        }
    }
}
