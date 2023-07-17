using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController characterController;

    [SerializeField] float speed = 5f;

    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    bool isDead = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>(); 
        
    }

    void Update()
    {
        if (isDead)
            return;

        moveVector = Vector3.zero;

        if (characterController.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        //X °ª - left right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        //Y °ª - up down
        moveVector.y = verticalVelocity;  

        //Z °ª - forward backward
        moveVector.z = speed;

        characterController.Move(moveVector * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if (hit.collider.name == "Cube")
        {
            Death();
        }
    }

    private void Death()
    {
        isDead = true;
        GetComponent<Score>().OnDeath();
    }
}
