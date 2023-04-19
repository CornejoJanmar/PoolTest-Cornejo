using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform BulletSpawnpoint;
    public float BulletSpeed;
    public GameObject SpawnFx;

    [SerializeField] List<GameObject> bulletList;
    [SerializeField] int poolAmount = 10;
    public GameObject bulletPrefab;

    private void Start()
    {
        bulletList = new List<GameObject>();
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject objBullet = (GameObject)Instantiate(bulletPrefab);
            objBullet.SetActive(false);
            bulletList.Add(objBullet);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shoot();
            //Instantiate(SpawnFX, BulletSpawnpoint.position, BulletSpawnpoint.rotation);
            //var bullet = Instantiate(BulletPrefab, BulletSpawnpoint.position, BulletSpawnpoint.rotation);
            //bullet.GetComponent<Rigidbody>().velocity = BulletSpawnpoint.forward * BulletSpeed;
        }
    }

    void shoot()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeInHierarchy)
            {
                bulletList[i].transform.position = BulletSpawnpoint.position;
                bulletList[i].transform.rotation = BulletSpawnpoint.rotation;
                bulletList[i].SetActive(true);
                Rigidbody tempRbBullet = bulletList[i].GetComponent<Rigidbody>();
                //tempRbBullet.AddForce(tempRbBullet.transform.forward * BulletSpeed);
                tempRbBullet.velocity = transform.right * BulletSpeed;
                break;
            }
        }
    }
}
