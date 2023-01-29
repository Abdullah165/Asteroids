using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;


    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletContainer;
    [SerializeField] List<GameObject> bulletPool;
    [SerializeField] int bullets;

    [SerializeField] Transform player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        bulletPool = GenerateBullets(bullets);
    }

    List<GameObject> GenerateBullets(int numberOfBullets)
    {
        for (int index = 0; index < numberOfBullets; index++)
        {
            GameObject bullet = Instantiate(bulletPrefab,player.position,Quaternion.identity);
            bullet.transform.parent = bulletContainer.transform;
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }

        return bulletPool;
    }

    public GameObject RequestBullet()
    {
        foreach(var bullet in bulletPool)
        {
            if(bullet.activeInHierarchy == false)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        GameObject newBullet = Instantiate(bulletPrefab,player.position, Quaternion.identity);
        newBullet.transform.parent = bulletContainer.transform;
        bulletPool.Add(newBullet);

        return newBullet;
    }
}
