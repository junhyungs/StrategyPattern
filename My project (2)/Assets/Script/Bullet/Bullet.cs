using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float attackDamage = 1f;
    protected int piercing = 1;
    protected float radius = 0f;
    protected bool explodeActive = false;

    public void InitBullet()
    {
        attackDamage = 1f;
        piercing = 1;
        radius = 0f;
        explodeActive = false;
    }
    
    public void SetBullet(float attackDamage, int piercing, float radius,bool explodeActive)
    {
        this.attackDamage = attackDamage;
        this.piercing = piercing;
        this.radius = radius;
        this.explodeActive = explodeActive;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        IHieAble hitAble = other.GetComponent<IHieAble>();

        if(hitAble != null)
        {
            if (!explodeActive)
            {
                hitAble.Damaged(attackDamage);
                piercing--;

                if(piercing == 0)
                {
                    gameObject.SetActive(false);
                }
            }
            else
            {
                Collider[] exploCollider = Physics.OverlapSphere(other.transform.position, radius, LayerMask.GetMask("EnemyTarget"));
                for(int i = 0; i < exploCollider.Length; i++)
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
