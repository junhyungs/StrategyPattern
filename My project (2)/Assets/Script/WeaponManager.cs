using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : Singleton<WeaponManager>
{
    public MyWeapon[] currentWeapon;
    public WeaponList weaponList;

    Dictionary<WeaponList, WeaponData> weaponDataDic;

    private void Awake()
    {
        weaponDataDic = new Dictionary<WeaponList, WeaponData>();

        weaponList = WeaponList.Gun;

        weaponDataDic.Add(WeaponList.Gun, new WeaponData(0.3f, 10f, 1f, 1, 0, false));
        weaponDataDic.Add(WeaponList.Bow, new WeaponData(0.3f, 10f, 1f, 1, 0, false));
        weaponDataDic.Add(WeaponList.Hand, new WeaponData(0.3f, 10f, 1f, 1, 0, false));
    }

    public void SetWeapon(WeaponList weapon)
    {
        weaponList = weapon;

        for(int i = 0; i < currentWeapon.Length; i++)
        {
            currentWeapon[i].SetWeapon(weapon);
        }
    }

    public WeaponData GetWeaponData(WeaponList weapon)
    {
        return weaponDataDic[weapon];
    }

}

public struct WeaponData
{
    public float rapidSpeed { get; }
    public float bulletSpeed { get; }
    public float attackDamage { get; }
    public int piercing { get; }
    public float radius { get; }
    public bool explodeActive { get; }

    public WeaponData(float rapidSpeed, float bulletSpeed, float attackDamage, int piercing, float radius, bool explodeActive) : this()
    {
        this.rapidSpeed = rapidSpeed;
        this.bulletSpeed = bulletSpeed;
        this.attackDamage = attackDamage;
        this.piercing = piercing;
        this.radius = radius;
        this.explodeActive = explodeActive;
    }
}