using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //public GameObject sensitivity;
    public float mouseSensitivity;
    public Transform playerBody;
    [SerializeField] public float croachDepth = 1f;
    [SerializeField] public bool croaching = false;
    [SerializeField] public float balooningDuration = 2f;

    public Transform cameraTransform;
    public Transform mainMenu;
    //bool isMenuOpen = true;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        cameraTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if (mainMenu.GetChild(0).gameObject.activeSelf == false)
        //{
            
        //}

        Smart_LookAround(0.5f);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            StartCoroutine(BaloonDown());
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(BaloonUp());
        }

    }

    void Smart_LookAround(float sensitivity)
    {
        // Get mouse position
        Vector3 mousePos = Input.mousePosition;
        
        // Calculate size of screen and middle point position
        double midX = Screen.width * 0.5;
        double midY = Screen.height * 0.5;

        // Calculate how far (in %) is mouse from mid point of the screen
        float mouseX = (float)((mousePos.x - midX) / midX);
        float mouseY = (float)((mousePos.y - midY) / midY);

        // Synchone FPS
        var speed = 100f;
        mouseX *= Time.deltaTime * speed;
        mouseY *= Time.deltaTime * speed;

        // Rotate view when right button is pressed on mouse
        if (Input.GetMouseButton(1))
        {
            cameraTransform.Rotate(-mouseY * sensitivity, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
            

        // Math.Abs(mouseY) > 0.01f && Math.Abs(mouseY) < 0.95f &&
        // Math.Abs(mouseX) > 0.01f && Math.Abs(mouseX) < 0.95f && 
    }

    void LookAround()
    {
        //TODO: CHeck mouse sensitivity VS pixel size of screen (HiDPI problem)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;// * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;// * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation * 0.5f, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX * 0.75f);
    }

    IEnumerator BaloonDown()
    {
        //This should be just one function, just the increments should change from positive to negative... :)
        float timeElapsed = 0f;
        float startValue = 0f;
        float endValue = -0.005f;
        float heightOfPerspective;

        while (timeElapsed < balooningDuration)
        {
            heightOfPerspective = Mathf.Lerp(startValue, endValue, timeElapsed / balooningDuration);
            cameraTransform.position = new Vector3(transform.position.x, transform.position.y + heightOfPerspective, transform.position.z);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
    }

    IEnumerator BaloonUp()
    {
        float timeElapsed = 0f;
        float startValue = 0f;
        float endValue = 0.005f;
        float heightOfPerspective;

        //Smaller increments needed, clamping as well
        // Need better clamping than this:  && cameraTransform.position.y > -1f && cameraTransform.position.y < 3f
        while (timeElapsed < balooningDuration)
        {
            heightOfPerspective = Mathf.Lerp(startValue, endValue, timeElapsed / balooningDuration);
            cameraTransform.position = new Vector3(transform.position.x, transform.position.y + heightOfPerspective, transform.position.z);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
    }

}
