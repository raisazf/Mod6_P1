using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCamera : MonoBehaviour    
{
    public Camera playerCamera;
    public float deltaX;
    public float deltaY;

    public float xRot; //rotation in deg
    public float yRot; //rotation in deg

    public float cameraSpeed = 2f;
    public float sensitivity = 3f;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main;
        Cursor.visible = false; // hide the cursor
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Keep track of the player's x and y rotations
        yRot += deltaX * sensitivity;
        xRot -= deltaY * sensitivity;

        // do not pass "shoulders"
        xRot  = Mathf.Clamp(xRot, -90f, 90f);

        //rotate the camera around x-axis

        //playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        //transform.rotation = Quaternion.Euler(0, yRot, 0);

        playerCamera.transform.localRotation = Quaternion.Slerp(playerCamera.transform.localRotation, Quaternion.Euler(xRot, 0, 0), Time.deltaTime * cameraSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yRot, 0), Time.deltaTime * cameraSpeed);

    }

    //OnCameraLook event handler

    public void OnCameraLook(InputValue value) 
    { 
        //reading the mouse deltas
        Vector2 inputVector = value.Get<Vector2>();

        deltaX = inputVector.x;
        deltaY = inputVector.y;
    }
}
