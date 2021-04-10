using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;

    Vector3 velocity;
    public float Gravity = -19.62f;
    public Transform GroundChecker;
    public float groundDist = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;


    public float jumpHeight = 3;

    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundChecker.position, groundDist, groundMask);
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        //Basic Movement
        //Get Keyboard inputs on axis
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Transform to transform
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * Gravity);
        }

        //Gravity & Velocity
        velocity.y += Gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


    }
}
