using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Fire : MonoBehaviour {

    public GameObject sleeve;
    public GameObject bullet;
    private GameObject bulletSpawnPoint;
    private GameObject sleeveSpawnPoint;


    public float fireRateLimit = 20;

    private float fireCount;

    private byte isShooting;

	void Start () {

        bulletSpawnPoint = Custom.findChildWithTag(gameObject, "bulletSpawn");
        sleeveSpawnPoint = Custom.findChildWithTag(gameObject, "sleeveSpawn");
    }

    void Update () {
        isShooting = (byte)(Input.GetAxisRaw("Fire1"));

    }

    private void FixedUpdate()
    {

        if (isShooting != 0)
        {
            if (fireCount == fireRateLimit || fireCount == 0)
            {
                Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
                Instantiate(sleeve, sleeveSpawnPoint.transform.position, sleeveSpawnPoint.transform.rotation);
                fireCount = 1;
            }
            else
            {
                fireCount++;
            }

        }
        else
        {
            fireCount = 0;
        }
        
    }
}
