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

    float xRotation = 20f;

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

        LookAround();

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            StartCoroutine(BaloonDown());
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(BaloonUp());
        }

    }

    void LookAround()
    {
        //TODO: CHeck mouse sensitivity VS pixel size of screen (HiDPI problem)
        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;// * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;// * Time.deltaTime;

        Vector3 mousePos = Input.mousePosition;
        {
            Debug.Log(mousePos.x);
            Debug.Log(mousePos.y);
        }
        double width = Screen.width * 0.5;
        float mouseX = (float) ((mousePos.x - width) / width);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if(Math.Abs(mouseX)> 0.15f)
            playerBody.Rotate(Vector3.up * mouseX);
    
        Debug.Log("Screen Width : " + Screen.width);
        Debug.Log("Screen Width : " + Screen.height);

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
