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

    //public float rotMin = -180;
    //public float rotMax = 180;

    public void Start()
    {
        slider0.value = robotArm0.rotation.y;
        slider1.value = robotArm1.rotation.z;
        slider2.value = robotArm2.rotation.z;
        slider3.value = robotArm3.rotation.x;
        slider4.value = robotArm4.rotation.z;
        slider5.value = robotArm5.rotation.x;
        //print("Robot arm0 rotation y: " + slider0.value);
        //print("Robot arm1 rotation y: " + slider1.value);
        //Adds a listener to the main slider and invokes a method when the value changes.
        slider0.onValueChanged.AddListener(delegate { CheckSlider0(); });
        slider1.onValueChanged.AddListener(delegate { CheckSlider1(); });
        slider2.onValueChanged.AddListener(delegate { CheckSlider2(); });
        slider3.onValueChanged.AddListener(delegate { CheckSlider3(); });
        slider4.onValueChanged.AddListener(delegate { CheckSlider4(); });
        slider5.onValueChanged.AddListener(delegate { CheckSlider5(); });
    }

    // Invoked when the value of the slider changes.
    public void CheckSlider0()
    {
        //Debug.Log(slider0.value);
        float sliderValue;
        sliderValue = slider0.value;
        //sliderValue = Remap(sliderValue, 0, 1, rotMin, rotMax);
        //Debug.Log(sliderValue);
        RotateArm0(sliderValue);
    }
    public void CheckSlider1()
    {
        //Debug.Log(slider1.value);
        float sliderValue;
        sliderValue = slider1.value;
        //sliderValue = Remap(sliderValue, 0, 1, rotMin, rotMax);
        //Debug.Log(sliderValue);
        RotateArm1(sliderValue);
    }
    public void CheckSlider2()
    {
        //Debug.Log(slider1.value);
        float sliderValue;
        sliderValue = slider2.value;
        //sliderValue = Remap(sliderValue, 0, 1, rotMin, rotMax);
        //Debug.Log(sliderValue);
        RotateArm2(sliderValue);
    }
    public void CheckSlider3()
    {
        //Debug.Log(slider1.value);
        float sliderValue;
        sliderValue = slider3.value;
        //sliderValue = Remap(sliderValue, 0, 1, rotMin, rotMax);
        //Debug.Log(sliderValue);
        RotateArm3(sliderValue);
    }
    public void CheckSlider4()
    {
        //Debug.Log(slider1.value);
        float sliderValue;
        sliderValue = slider4.value;
        //sliderValue = Remap(sliderValue, 0, 1, rotMin, rotMax);
        //Debug.Log(sliderValue);
        RotateArm4(sliderValue);
    }
    public void CheckSlider5()
    {
        //Debug.Log(slider1.value);
        float sliderValue;
        sliderValue = slider5.value;
        //sliderValue = Remap(sliderValue, 0, 1, rotMin, rotMax);
        //Debug.Log(sliderValue);
        RotateArm5(sliderValue);
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
        Debug.Log("Arm rotatied this much: " + rot);
        switch (whichAxis)
        {
            case 0:
                //currentArm.Rotate(rot, 0f, 0f, Space.Self);
                currentArm.transform.localEulerAngles = new Vector3(rot, 0, 0);
                //currentArm.SetPositionAndRotation(currentArm.position, Quaternion.Euler(rot, 0f, 0f));
                //currentArm.rotation = Quaternion.Euler(rot, 0f, 0f);
                break;
            case 1:
                //currentArm.Rotate(0f, rot, 0f, Space.Self);
                currentArm.transform.localEulerAngles = new Vector3(0, rot, 0);
                //currentArm.SetPositionAndRotation(currentArm.position, Quaternion.Euler(0f, rot, 0f));
                //currentArm.rotation = Quaternion.Euler(0f, rot, 0f);
                break;
            case 2:
                //currentArm.Rotate(0f, 0f, rot, Space.Self);
                currentArm.transform.localEulerAngles = new Vector3(0, 0, rot);
                //currentArm.SetPositionAndRotation(currentArm.position, Quaternion.Euler(new Vector3(0f, 0f, rot)));
                //currentArm.rotation = Quaternion.Euler(0f, 0f, rot);
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
