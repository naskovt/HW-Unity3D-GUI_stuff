using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_rotation : MonoBehaviour {

    void FixedUpdate()
    {
        RotateCube();
    }

    private void RotateCube()
    {
        transform.Rotate(Vector3.up, Space.Self);
    }

}
