using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twilight : MonoBehaviour
{
    public Light myLight;

    //Range Variables
    public bool changeRange = false;
    public float rangeSpeed = 1.0f;
    public float maxRange = 10.0f;
    public bool repeatRange = false;

    //Intensity Variables
    public bool changeIntensity = false;
    public float intensitySpeed = 1.0f;
    public float maxIntensity = 10.0f;
    public bool repeatIntensity = false;

    //Color Variables
    public bool changeColors = false;
    public float colorSpeed = 1.0f;
    public Color startColor;
    public Color endColor;
    public bool repeatColor = false;

    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
        startTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (changeRange)
        {
            if (repeatRange) {

                myLight.range = Mathf.PingPong(Time.time * rangeSpeed, maxRange);
            } else
            {
                myLight.range = Time.time * rangeSpeed;
                if(myLight.range >= maxRange)
                {
                    changeRange = false;
                }
            }
            
            
        }

        if (changeIntensity)
        {
            if (repeatIntensity)
            {

                myLight.intensity = Mathf.PingPong(Time.time * intensitySpeed, maxIntensity);
            }
            else
            {
                myLight.intensity = Time.time * rangeSpeed;
                if (myLight.intensity >= maxRange)
                {
                    changeIntensity = false;
                }
            }
        }

        if (changeColors)
        {
            float t = (Mathf.Sin(Time.time - startTime * colorSpeed));
            myLight.color = Color.Lerp(startColor, endColor, t);
        }
    }
}
