using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix_BulletStopping : MonoBehaviour {

    private GameObject[] bullets;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {

        //bullets = GameObject.FindGameObjectsWithTag("Player");

        bullets = GameObject.FindGameObjectsWithTag("bullet");

        foreach (var item in bullets)
        {
            if (item.transform.position.z > 3)
            {
                Destroy(item.GetComponent<Rigidbody>());
            }
            print(item.name);
        }


	}
}
