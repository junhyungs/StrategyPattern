using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon, IWeapon
{
    public override void Fire()
    {
        base.Fire();
    }

    private void Start()
    {
        weaponData = WeaponManager.Instance.GetWeaponData(WeaponList.Gun);
    }
}
