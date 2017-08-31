using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_movement : MonoBehaviour {

    private Collider col;
    public GameObject doorAxis;

    private float rotateDoorAngle = 80;
    private float smoothDoorMovement = 0.1f;
    private bool isDoorOpened = false;
    private bool isPlayerInRange = false;
    private bool isMousePositionOnDoor = false;

    void Start () {
        col = GetComponent<Collider>();
	}
	
	void FixedUpdate () {

        if (isDoorOpened)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }

        if (isPlayerInRange && Input.GetMouseButtonDown(0) && IsMousePositionOnDoor())
        {
            isDoorOpened = true;
        }

    }

    private bool IsMousePositionOnDoor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000) && hit.transform.tag == "door")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerInRange = false;
            isDoorOpened = false;
        }

    }

    private void OpenDoor()
    {
        doorAxis.transform.rotation = Quaternion.Slerp(doorAxis.transform.rotation,  Quaternion.Euler(0, rotateDoorAngle, 0), smoothDoorMovement);
    }

    private void CloseDoor()
    {
        doorAxis.transform.rotation = Quaternion.Slerp(doorAxis.transform.rotation, Quaternion.Euler(0, 0, 0), smoothDoorMovement);
    }


}
