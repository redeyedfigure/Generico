using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [Header("Object References")]
    [SerializeField] Transform playerBody;

    [Header("Basic Parameters")]
    [SerializeField] float mouseSensitivity = 100f;

    float xRotation = 0f;

    void Start()
    {
        //Makes cursor invisible, locked in center of screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Gets Player Input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Rotate the camera over the x axis, in accordance with the y axis of mouse input
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Rotate the player body, in accordance with the x axis of mouse input
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
