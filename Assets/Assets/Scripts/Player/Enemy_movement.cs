using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_movement : MonoBehaviour {

    public GameObject target;

    private Vector3 targetDirection;
    private Vector3 verticalVector;
    private Vector3 rotateVector;

    private Camera cameraObject;
    private Rigidbody rb;

    public float movingSpeed = 1;
    public float rotateMovingSpeed = 1;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        #region Get vector pointing towards the target

        targetDirection = target.transform.position - transform.position;

        #endregion

    }

    void FixedUpdate()
    {
        //rotate smoothly the enemy against the player
        rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(targetDirection), rotateMovingSpeed * Time.deltaTime);

        #region Move the enemy towards the player

        //rb.AddForce(targetDirection * movingSpeed * 100, ForceMode.Force);

        #endregion


    }

}