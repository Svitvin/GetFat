using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigegrDoctorMove : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool("MoveColbe", true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
