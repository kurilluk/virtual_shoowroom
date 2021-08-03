using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //public GameObject sensitivity;
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    //bool isMenuOpen = true;

    float xRotation = 20f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update() 
    { 
        //TODO: CHeck mouse sensitivity VS pixel size of screen (HiDPI problem)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
