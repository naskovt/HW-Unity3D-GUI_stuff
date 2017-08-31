using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleeve_destroy : MonoBehaviour {

    private float destroyAfterTime = 5;
    private float timePassed;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        timePassed += Time.deltaTime;

        if ( timePassed > destroyAfterTime )
        {
            Destroy(this.gameObject);
        }
	}
}
