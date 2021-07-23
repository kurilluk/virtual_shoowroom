﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnsMovement : MonoBehaviour
{
    //public GameObject PreviewModeManager;
    public GameObject sloup;

    private bool shouldLerp = false;

    public float timeStartedLerping;
    public float lerpTime;
    public float speed = 1;

    public Vector3 endPosition;
    public Vector3 startPosition;

    public PreviewModeManager manager;


    private void StartLerping()
    {
        timeStartedLerping = Time.time;

        shouldLerp = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        if (RunMode.Develop)
            transform.position = endPosition;
        else
            StartLerping();
    }

    // Update is called once per frame
    void Update()
    {
        //Call the Lerp only if the PreviewModeManager allows it. Using PreviewModeManager.CollumnsAnimation in the if statement. Not sure if this works fine...
        if (shouldLerp) //manager.CollumnsAnimation, !RunMode.Develop
        //Input.GetKey("q")
        {
            //Debug.Log("Manager status:" + RunMode.Develop);
            shouldLerp = true;
                        
            transform.position = Lerp(startPosition, endPosition, timeStartedLerping, lerpTime);
        }        
    }

    public Vector3 Lerp(Vector3 start, Vector3 end, float timeStartedLerping, float lerpTime = 1)
    {
        float timeSinceStarted = Time.time - timeStartedLerping;

        float percentageComplete = timeSinceStarted / lerpTime;

        var result = Vector3.Lerp(start, end, percentageComplete);

        return result;
    }
}
