using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //public GameObject sensitivity;
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    [SerializeField] public float croachDepth = 1f;
    [SerializeField] public bool croaching = false;

    public Transform cameraTransform;
    public Transform mainMenu;
    //bool isMenuOpen = true;

    float xRotation = 20f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cameraTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainMenu.GetChild(0).gameObject.activeSelf == false)
        {
            
        }
        LookAround();
        //if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.RightControl))
        //if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        //{
        //    Debug.Log("Control pressed");

        //    cameraTransform.position = new Vector3 (transform.position.x, transform.position.y - croachDepth, transform.position.z);
        //    Debug.Log(cameraTransform.position.y);
        //}
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Croach();
        }

    }

    void LookAround()
    {
        //TODO: CHeck mouse sensitivity VS pixel size of screen (HiDPI problem)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }

    void Croach()
    {

        if (!croaching)
        {
            croaching = true;
            //With LERP in order to make the Baloon effect
            cameraTransform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, transform.position.y - croachDepth, 2f), transform.position.z);

            //cameraTransform.position = new Vector3(transform.position.x, transform.position.y - croachDepth, transform.position.z);
        }
        else
        {
            croaching = false;
            cameraTransform.position = new Vector3(transform.position.x, transform.position.y + croachDepth, transform.position.z);
        }

    }
}
