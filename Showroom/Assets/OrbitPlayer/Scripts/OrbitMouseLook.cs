using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMouseLook : MonoBehaviour
{
    public Transform cameraRig;
    public Transform cameraObject;

    public float mouseSensitivity;
    public float scrollSensitivity;

    private float xrot;
    private float yrot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitingMouseLook();
    }

    private void OrbitingMouseLook() 
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        mouseX -= yrot;
        mouseY -= xrot;

        //Need local rotation for this
        //transform.rotation = Quaternion.Euler(xrot, yrot, 0);
        cameraRig.localEulerAngles = new Vector3(xrot, yrot, 0);
    }
}
