using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smart_Twilight : MonoBehaviour
{
    public float maxIntensity;
    public float maxRange;
    public float speed;

    public Color startColor;
    public Color endColor;

    private Light[] _lights;


    // Start is called before the first frame update
    void Start()
    {
        // Read all children lights
        _lights = gameObject.GetComponentsInChildren<Light>(true);

        foreach (Light light in _lights)
        {
            light.intensity = 0f;
            //light.range = 0f;

            //StartCoroutine(IncreaseIntensity(light));
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            StopAllCoroutines();
            foreach(Light light in _lights)
                StartCoroutine(IncreaseIntensity(light));
        }

        if (Input.GetKeyDown("u"))
        {
            StopAllCoroutines();
            foreach (Light light in _lights)
                StartCoroutine(DecreaseIntensity(light));
        }

        if (Input.GetKeyDown("o"))
        {
            StopAllCoroutines();
            foreach (Light light in _lights)
                StartCoroutine(Animation(light));
        }
    }

    IEnumerator IncreaseIntensity(Light light)
    {
        for (float i = light.intensity; i < maxIntensity; i += Time.deltaTime * speed)
        {
            Debug.Log(light.name + ".i= " + i);
            light.intensity = i;
            yield return null;
        }
    }
    IEnumerator DecreaseIntensity(Light light)
    {
        for (float i = light.intensity; i > 0; i -= Time.deltaTime * speed)
        {
            Debug.Log(light.name + ".i= " + i);
            light.intensity = i;
            yield return null;
        }
    }

    IEnumerator Animation(Light light)
    {
        for(float i = 0f; i <= 1f; i += Time.deltaTime * speed)
        {
            light.intensity = maxIntensity * i;
            light.range = maxRange * i;
            light.color = Color.Lerp(startColor, endColor, i);
            Debug.Log(light.name + ".i= " + i);
            yield return null;        
        }

    }
}
