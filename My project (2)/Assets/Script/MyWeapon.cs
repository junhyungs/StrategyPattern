using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponList
{
    Gun,
    Bow,
    Hand
}

public class MyWeapon : MonoBehaviour
{
    public GameObject[] Weapon;
    private IWeapon iweapon;
    private WeaponList weaponList;

    void Start()
    {
        InitWeapon();
    }

    private void OnEnable()
    {
        InitWeapon();
    }

    public void InitWeapon()
    {
        SetWeapon(WeaponManager.Instance.weaponList);
    }

    public void SetWeapon(WeaponList weaponList)
    {
        this.weaponList = weaponList;

        DeactiveAllWeapon();

        Component component = gameObject.GetComponent<IWeapon>() as Component;

        if(component != null )
        {
            Destroy(component);
        }

        switch(weaponList)
        {
            case WeaponList.Gun:
                iweapon = gameObject.AddComponent<Gun>();
                break;
            case WeaponList.Bow:
                iweapon = gameObject.AddComponent<Bow>();
                break;
            case WeaponList.Hand:
                iweapon = gameObject.AddComponent<Hand>();
                break;
        }

        GameObject weaponPrefab = Weapon[(int)weaponList];

        if( weaponPrefab != null )
        {
            weaponPrefab.SetActive(true);
        }

    }

    private void Update()
    {
        iweapon.Fire();

        if (Input.GetKeyUp(KeyCode.F1))
        {
            SetWeapon(WeaponList.Gun);
            Debug.Log("ÃÑ");
        }
        else if (Input.GetKeyUp(KeyCode.F2))
        {
            SetWeapon(WeaponList.Bow);
            Debug.Log("È°");
        }
        else if (Input.GetKeyUp(KeyCode.F3))
        {
            SetWeapon(WeaponList.Hand);
            Debug.Log("¼Õ");
        }
    }

    private void DeactiveAllWeapon()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

}
