using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour
{
    protected Animator anim;
    [SerializeField] public GameObject enemyModel;
    RagdollController ragdoll;
    protected GameObject hero;
    protected bool triggered = false;
    public bool collided = false;
    protected float speed = 2;

    void Start()
    {
        anim = enemyModel.GetComponent<Animator>();
        AnimatorStartConfig();
        ragdoll = GetComponent<RagdollController>();
        hero = GameObject.Find("Hero");
    }

    void Update()
    {
        if(!collided)
        {
            StandartLogic();
        }
    }

    /*public void Punch()
    {
        DisableAnimations();
        ragdoll.GetRigidbody(1).AddForce(-transform.forward * 30, ForceMode.Impulse);
        collided = true;
    }*/


    abstract protected void AnimatorStartConfig();
    abstract protected void StandartLogic();
    //abstract protected void DisableAnimations();
}
