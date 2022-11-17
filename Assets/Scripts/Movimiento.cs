using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 20f;
    public float gravity = -9.8f;
    public float jumpHeight = 3;

    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if ( isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //movimiento en ambos ejes (los lados y atrás)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 movement = transform.right * x + transform.forward * z;
        controller.Move(movement * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // la velocidad en el eje y equivale a
            // una formula fisica para saltar
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }
} 
