using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Basic Object References")]
    [SerializeField] CharacterController controller;

    [Header("Basic Parameters")]
    [SerializeField] float walkSpeed = 12f;
    [SerializeField] float runSpeed = 18f;
    [SerializeField] float smoothSpeed = 0.4f;

    //Running-related material
    public float currentSpeed;
    bool isMoving;

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

        //Check if the player is moving
        if(x != 0 || y != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        //Running and walking with linear interpolation
        if(isMoving && !Input.GetKey(KeyCode.LeftShift) && currentSpeed != walkSpeed)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, walkSpeed, smoothSpeed);
        } 
        else if(isMoving && Input.GetKey(KeyCode.LeftShift) && currentSpeed != runSpeed)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, runSpeed, smoothSpeed);
        }
        else if(!isMoving)
        {
            currentSpeed = 0;
        }

        //Increasing performance(maybe) by autocorrecting numbers within a small range of the desired number
        if (currentSpeed > (runSpeed - 0.05) && Input.GetKey(KeyCode.LeftShift))
            currentSpeed = runSpeed;
        if ((currentSpeed < (walkSpeed + 0.05) && currentSpeed > walkSpeed) || (currentSpeed > (walkSpeed - 0.05) && currentSpeed < walkSpeed) && !Input.GetKey(KeyCode.LeftShift))
            currentSpeed = walkSpeed;

        //Basic Movement
        move = transform.right * x + transform.forward * y;
        controller.Move(move * currentSpeed * Time.deltaTime);

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
