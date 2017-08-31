using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Movement : MonoBehaviour {

    public float bulletExplosiveSpeed = 8f;
    private float timePassed;
    private Rigidbody rb;
    private RaycastHit hit;

    void Start () {

        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.up * bulletExplosiveSpeed, ForceMode.Impulse);

    }

    void FixedUpdate () {

        timePassed += Time.deltaTime;

        DestroyBullet(1f);

	}


    void DestroyBullet(float bulletLifetime)
    {
        if (timePassed > bulletLifetime)
        {
            Destroy(this.gameObject);
        }
        
    }
}
