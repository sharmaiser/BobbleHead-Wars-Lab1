﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 50.0f;
    private CharacterController characterController;
    public LayerMask layerMask;
    private Vector3 currentLookTarget = Vector3.zero;

    public Rigidbody head;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"),
            0, Input.GetAxis("Vertical"));
        characterController.SimpleMove(moveDirection * moveSpeed);
    }

    void FixedUpdate()
    {

        //This code moves the head when marine moves.
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"),
            0, Input.GetAxis("Vertical"));

        //If the value equals vector zero marine is still standing.
        if(moveDirection==Vector3.zero)
        {
            //ToDo
        }
        else
        {
            //Direction and Force amount are multiplied
            head.AddForce(transform.right * 150, ForceMode.Acceleration);
        }
        //Creating an empty ray
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //This will draw ray in scene
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);
        
        //Ray actually cast rays and layer mask lets cast know you are tring to hit
        if (Physics.Raycast(ray, out hit, 1000, layerMask,
                            QueryTriggerInteraction.Ignore))
        {
            if (hit.point != currentLookTarget)
            {
                currentLookTarget = hit.point;
            }

            // You get the target position 
            Vector3 targetPosition = new Vector3(hit.point.x,
            transform.position.y, hit.point.z);
            // Calculate the quaternion for the rotation
            Quaternion rotation = Quaternion.LookRotation(targetPosition -
            transform.position);
            // Using Lerp() for smoother rotation for our Marine 
            transform.rotation = Quaternion.Lerp(transform.rotation,
            rotation, Time.deltaTime * 10.0f);
        }

    }
}
