using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMouseLook : MonoBehaviour
{
    public Transform cameraRig;
    public Transform cameraObject;

    public float mouseSensitivity;

    public float minFov = 35f;
    public float maxFov = 100f;
    public float scrollSensitivity;


    // Update is called once per frame
    void Update()
    {
        OrbittingMouseLook();
    }

    private void OrbittingMouseLook() 
    {
        if (Input.GetMouseButton(1)) {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            //TODO: Clamping the values

            cameraRig.transform.RotateAround(cameraRig.transform.position, cameraRig.transform.up, mouseX);
            cameraObject.transform.RotateAround(cameraRig.transform.position, cameraRig.transform.forward, -mouseY);

            //TODO: Zoom
            float fov = Camera.main.fieldOfView;
            fov += Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            Camera.main.fieldOfView = fov;
        }

    }
}
