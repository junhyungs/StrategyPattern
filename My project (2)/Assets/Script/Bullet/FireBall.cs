using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Bullet
{
    public override void OnTriggerEnter(Collider other)
    {
        IHieAble hitAble = other.GetComponent<IHieAble>();

        if (hitAble != null)
        {
            if (!explodeActive)
            {
                hitAble.Damaged(attackDamage);
                piercing--;

                if (piercing == 0)
                {
                    gameObject.SetActive(false);
                }
            }
            else
            {
                Collider[] exploCollider = Physics.OverlapSphere(other.transform.position, radius, LayerMask.GetMask("EnemyTarget"));
                for (int i = 0; i < exploCollider.Length; i++)
                {
                    hitAble = exploCollider[i].GetComponent<IHieAble>();
                    hitAble.Damaged(attackDamage);
                }
                piercing--;
                if (piercing == 0)
                    gameObject.SetActive(false);
            }
        }
    }
}
