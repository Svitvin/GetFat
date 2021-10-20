using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningEnemy : Enemy
{
    protected override void AnimatorStartConfig()
    {
        anim.SetBool("Move", false);
    }
    protected override void StandartLogic()
    {
        Vector3 toHero = hero.transform.position - transform.position;

        if (!triggered)
        {
            float distance = toHero.magnitude;

            if (distance < 2)
            {
                triggered = true;
                anim.SetBool("Move", true);
            }
        }
        else
        {
            Vector3 movement;

            if (Vector3.Angle(toHero, transform.forward) < 40)
            {
                movement = new Vector3 (toHero.x, 0, toHero.z);
            }
            else
            {
                movement = transform.forward;
            }

            enemyModel.transform.rotation = Quaternion.AngleAxis(Vector3.Angle(Vector3.forward, movement), Vector3.up);

            transform.position += movement.normalized * speed * Time.deltaTime;
        }
    }

    /*protected override void DisableAnimations()
    {
        Destroy(anim);
    }*/
}
