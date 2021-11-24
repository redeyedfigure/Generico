using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Basic Object References")]
    [SerializeField] CharacterController controller;

    [Header("Basic Parameters")]
    [SerializeField] float speed = 12f;

    [Header("Ground Checking")]
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    bool isGrounded;

    [Header("Jump-Related")]
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] float gravity = -9.81f;

    //Vectors
    [HideInInspector] public Vector3 velocity;
    Vector3 move;
    Vector2 moveInput;

    void Update()
    {
        //Input References
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //Basic Movement
        move = transform.right * x + transform.forward * y;
        controller.Move(move * speed * Time.deltaTime);

        //Ground-Checking
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Applying Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //Jump
        if (isGrounded && Input.GetButtonDown("Jump"))
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
}
