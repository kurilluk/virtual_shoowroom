using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smart_Twilight : MonoBehaviour
{
    public float maxIntensity;
    public float speed;

    private Light[] lights;


    // Start is called before the first frame update
    void Start()
    {
        // Read all children lights
        lights = gameObject.GetComponentsInChildren<Light>(true);

        foreach (Light light in lights)
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
            foreach(Light light in lights)
                StartCoroutine(IncreaseIntensity(light));
        }

        if (Input.GetKeyDown("u"))
        {
            StopAllCoroutines();
            foreach (Light light in lights)
                StartCoroutine(DecreaseIntensity(light));
        }
    }

    IEnumerator IncreaseIntensity(Light light)
    {
        for (float i = light.intensity; i < maxIntensity; i += Time.deltaTime * speed)
        {
            //Debug.Log(light.name + ".i= " + i);
            light.intensity = i;
            yield return null;
        }
    }
    IEnumerator DecreaseIntensity(Light light)
    {
        for (float i = light.intensity; i > 0; i -= Time.deltaTime * speed)
        {
            //Debug.Log(light.name + ".i= " + i);
            light.intensity = i;
            yield return null;
        }
    }
}
