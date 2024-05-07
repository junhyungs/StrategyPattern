using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon, IWeapon
{
    public override void Fire()
    {
        if (time > weaponData.rapidSpeed)
        {
            GameObject bulletObject = PoolManager.Instance.GetArrow();
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

    
    void Start()
    {
        weaponData = WeaponManager.Instance.GetWeaponData(WeaponList.Bow);
    }

    
}
