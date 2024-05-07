using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour,IWeapon
{

    protected WeaponData weaponData;
    protected float time;


    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime; 
    }

    public virtual void Fire()
    {
        if(time > weaponData.rapidSpeed)
        {
            GameObject bulletObject = PoolManager.Instance.GetBullet();
            Rigidbody rigid = bulletObject.GetComponent<Rigidbody>();
            rigid.velocity = Vector3.zero;
            rigid.velocity = new Vector3(0, 0, weaponData.bulletSpeed);
            bulletObject.transform.position = transform.position;

            Bullet bullet = bulletObject.GetComponent<Bullet>();
            bullet.InitBullet();
            bullet.SetBullet(weaponData.attackDamage, weaponData.piercing, weaponData.radius, weaponData.explodeActive);
            
            time = 0;
        }
    }
}
