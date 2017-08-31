using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvas_lookAt : MonoBehaviour {

    public Camera camera;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camera.transform.position);
    }
}
