using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMoveJ : MonoBehaviour
{
    public Transform robotTransform;


    public Transform robotArm0;
    public Transform robotArm1;
    public Transform robotArm2;
    public Transform robotArm3;
    public Transform robotArm4;
    public Transform robotArm5;

    //public GameObject slider0;
    //public GameObject slider1;
    //public GameObject slider2;
    //public GameObject slider3;
    //public GameObject slider4;
    //public GameObject slider5;

    public float rotationSpeed = 100f;

    public Slider slider0;
    public Slider slider1;
    public Slider slider2;
    public Slider slider3;
    public Slider slider4;
    public Slider slider5;

    public float rotMin = -180;
    public float rotMax = 180;

    public void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        slider0.onValueChanged.AddListener(delegate { CheckSlider0(); });
        slider1.onValueChanged.AddListener(delegate { CheckSlider1(); });
    }

    // Invoked when the value of the slider changes.
    public void CheckSlider0()
    {
        Debug.Log(slider0.value);
        float sliderValue;
        sliderValue = slider0.value;
        sliderValue = Remap(sliderValue, 0, 1, rotMin, rotMax);
        Debug.Log(sliderValue);
        RotateArm0(sliderValue);
    }

    public void CheckSlider1()
    {
        Debug.Log(slider1.value);
        float sliderValue;
        sliderValue = slider1.value;
        sliderValue = Remap(sliderValue, 0, 1, rotMin, rotMax);
        Debug.Log(sliderValue);
        RotateArm1(sliderValue);
    }


    public float Remap(float from, float fromMin, float fromMax, float toMin, float toMax)
    {
        var fromAbs = from - fromMin;
        var fromMaxAbs = fromMax - fromMin;

        var normal = fromAbs / fromMaxAbs;

        var toMaxAbs = toMax - toMin;
        var toAbs = toMaxAbs * normal;

        var to = toAbs + toMin;

        return to;
    }

    public void RotateArm0(float rotAmount)
    {
        RotateArm(rotAmount, robotArm0, 1);
    }

    public void RotateArm1(float rotAmount)
    {
        RotateArm(rotAmount, robotArm1, 2);
    }

    public void RotateArm2(float rotAmount)
    {
        RotateArm(rotAmount, robotArm2, 2);
    }

    public void RotateArm3(float rotAmount)
    {
        RotateArm(rotAmount, robotArm3, 0);
    }

    public void RotateArm4(float rotAmount)
    {
        RotateArm(rotAmount, robotArm4, 2);
    }

    public void RotateArm5(float rotAmount)
    {
        RotateArm(rotAmount, robotArm5, 0);
    }

    public void RotateArm(float rotAmount, Transform currentArm, int whichAxis)
    {
        //float rot = rotAmount * rotationSpeed * Time.deltaTime;
        float rot = rotAmount * rotationSpeed;
        //Debug.Log(rot);
        switch (whichAxis)
        {
            case 0:
                //currentArm.Rotate(rot, 0f, 0f, Space.Self); 
                currentArm.SetPositionAndRotation(currentArm.position, Quaternion.Euler(new Vector3(rot, 0f, 0f)));
                break;
            case 1:
                //currentArm.Rotate(0f, rot, 0f, Space.Self);
                currentArm.SetPositionAndRotation(currentArm.position, Quaternion.Euler(new Vector3(0f, rot, 0f)));
                break;
            case 2:
                //currentArm.Rotate(0f, 0f, rot, Space.Self);
                currentArm.SetPositionAndRotation(currentArm.position, Quaternion.Euler(new Vector3(0f, 0f, rot)));
                break;
            default:
                break;
        }
    }

    //public float Remap(this float from, float fromMin, float fromMax, float toMin, float toMax)
    //{
    //    var fromAbs = from - fromMin;
    //    var fromMaxAbs = fromMax - fromMin;

    //    var normal = fromAbs / fromMaxAbs;

    //    var toMaxAbs = toMax - toMin;
    //    var toAbs = toMaxAbs * normal;

    //    var to = toAbs + toMin;

    //    return to;
    //}
}
