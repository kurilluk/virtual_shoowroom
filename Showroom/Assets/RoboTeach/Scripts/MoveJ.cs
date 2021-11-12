using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJ : MonoBehaviour
{
    public Transform robotTransform;

    
    public Transform robotArm0;
    public Transform robotArm1;
    public Transform robotArm2;
    public Transform robotArm3;
    public Transform robotArm4;
    public Transform robotArm5;

    public float rotationSpeed = 100f;


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
        float rot = rotAmount * rotationSpeed * Time.deltaTime;
        //Debug.Log(rot);
        switch (whichAxis)
        {
            case 0:
                currentArm.Rotate(rot, 0f, 0f, Space.Self);
                break;
            case 1:
                currentArm.Rotate(0f, rot, 0f, Space.Self);
                break;
            case 2:
                currentArm.Rotate(0f, 0f, rot, Space.Self);
                break;
            default:
                break;
        }
    }
}
