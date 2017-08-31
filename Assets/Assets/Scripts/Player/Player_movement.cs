using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System;

public class Player_movement : MonoBehaviour {

    private Vector3 horizontalVector;
    private Vector3 verticalVector;
    private Vector3 rotateVector;
    private Rigidbody rb;
    private bool isPlayerOnGround = true;
    private float maxRotation = 6;
    private float minRotation = -20;
    private Vector3 eulerAngles;
    private float rotationSpeed = 4;
    private float tempSpeedTest;

    public GameObject player;
    public Camera cameraObject;
    public float movingSpeed = 1;
    public float jumpPower = 2f;
    public Slider movementSpeedSlider;
    public Slider rotationSpeedSlider;
    public Slider jumpPowerSlider;
    public Slider diffScroll;

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        rotationSpeedSlider.onValueChanged.AddListener(delegate { ValueChange(ref rotationSpeed, rotationSpeedSlider); } );
        movementSpeedSlider.onValueChanged.AddListener(delegate { ValueChange(ref movingSpeed, movementSpeedSlider); } );
        jumpPowerSlider.onValueChanged.AddListener(delegate { ValueChange(ref jumpPower, jumpPowerSlider); });
        diffScroll.onValueChanged.AddListener(delegate { GetComponent<player_health>().ChangeDifficulty((int)diffScroll.value); });
    }

    private void ValueChange(ref float value, Slider slider)
    {
        value = slider.value;
    }

    void Update() {

        #region Rotation vector

        rotateVector = new Vector3(Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"), 0);

        #endregion

        #region Creating vectors for moving forward/backward

            if (Input.GetKey("up") || Input.GetKey("w"))
            {
                verticalVector = transform.forward;
            }
            else if(Input.GetKey("down") || Input.GetKey("s"))
            {
                verticalVector = -transform.forward;
            }
            else
            {
                verticalVector = Vector3.zero;
            }

        #endregion

        #region Creating vectors for moving left/right

            if (Input.GetKey("left") || Input.GetKey("a"))
            {
                horizontalVector = -transform.right;
            }
            else if (Input.GetKey("right") || Input.GetKey("d"))
            {
                horizontalVector = transform.right;
            }
            else
            {
                horizontalVector = Vector3.zero;
            }

        #endregion

    }

    private void Jump()
    {
        //check if the player touches the ground in order to disable jumping in air
        if (isPlayerOnGround)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    void FixedUpdate () {

        #region Jump listen

        if (Input.GetKeyDown("space"))
        {
            Jump();
        }

        #endregion

        Vector3 movingVector = (verticalVector + horizontalVector) * Time.deltaTime * movingSpeed;

        //move player to sides
        rb.MovePosition(movingVector + transform.position);

        //rotate player left/right
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, rotateVector.y * rotationSpeed, 0));

        //rotate camera up/down based on the input
        cameraObject.transform.localEulerAngles = -eulerAngles;

        //assign new inout data to the working variable
        eulerAngles.x += rotateVector.x;

        #region Check if the next rotation is inside the constraint

        if (eulerAngles.x < minRotation)
        {
            eulerAngles.x = minRotation;
        }
        if (eulerAngles.x > maxRotation)
        {
            eulerAngles.x = maxRotation;
        }

        #endregion
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.collider.tag == "ground")
        {
            isPlayerOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            isPlayerOnGround = true;
        }
    }
}
