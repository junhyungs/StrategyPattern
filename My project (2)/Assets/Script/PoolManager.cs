using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    [SerializeField]
    private Transform[] BulletPoolTransform;
    [SerializeField]
    private GameObject[] BulletPrefab;

    private Queue<GameObject>[] BulletPool;

    private void Awake()
    {
        BulletPool = new Queue<GameObject>[BulletPrefab.Length];

        for(int i = 0; i < BulletPrefab.Length; i++)
        {
            BulletPool[i] = new Queue<GameObject>();
        }

        for(int i = 0; i < 100; i++)
        {
            GameObject bulletPrefab = Instantiate(BulletPrefab[0], BulletPoolTransform[0]);
            bulletPrefab.SetActive(false);
            BulletPool[0].Enqueue(bulletPrefab);
        }

        for(int i = 0; i < 100; i++)
        {
            GameObject arrowPrefab = Instantiate(BulletPrefab[1], BulletPoolTransform[1]);
            arrowPrefab.SetActive(false);
            BulletPool[1].Enqueue(arrowPrefab);
        }

        for(int i = 0; i < 100; i++)
        {
            GameObject fireballPrefab = Instantiate(BulletPrefab[2], BulletPoolTransform[2]);
            fireballPrefab.SetActive(false);
            BulletPool[2].Enqueue(fireballPrefab);
        }

    }

    public GameObject GetBullet()
    {
        GameObject bullet = BulletPool[0].Dequeue();
        BulletPool[0].Enqueue(bullet);
        bullet.SetActive(true);
        return bullet;
    }

    public GameObject GetArrow()
    {
        GameObject arrow = BulletPool[1].Dequeue();
        BulletPool[1].Enqueue(arrow);
        arrow.SetActive(true);
        return arrow;
    }

    public GameObject GetFireBall()
    {
        GameObject fireball = BulletPool[2].Dequeue();
        BulletPool[2].Enqueue(fireball);
        fireball.SetActive(true);
        return fireball;
    }

}
