using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [Space]
    [SerializeField]
    [Range(-1, 1)]
    float motion;

    [SerializeField]
    bool isMotion;

    [Space]
    [SerializeField]
    Vector3 leftBorder;

    [Space]
    [SerializeField]
    Vector3 rightBorder;

    float moveDirection = 1;

    private void Update()
    {
        animator.SetFloat("Motion", motion);

        animator.SetBool("IsMotion", isMotion);

        if (isMotion)
        {
            if (moveDirection == 1 && motion >= 1) moveDirection = -1;
            if (moveDirection == -1 && motion <= -1) moveDirection = 1;

            motion += moveDirection * Time.deltaTime;

            if (moveDirection == -1) transform.Translate(leftBorder * Time.deltaTime);
            else if (moveDirection == 1) transform.Translate(rightBorder * Time.deltaTime);
        }
    }
}
