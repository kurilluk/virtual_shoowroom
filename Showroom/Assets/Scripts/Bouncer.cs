using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField] private float bounceSpeed = 2f;

    //private float speed = 1f;
    private Vector3 scaleChange;
    
    // Start is called before the first frame update
    void Awake()
    {
        scaleChange = Vector3.one * 0.21f;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(transform.localScale.y);
        //Very simple bouncing using LERP on scale of the object transform...
        if (transform.localScale.y > 0.2f)
        {
            scaleChange = Vector3.one * 0.05f;
        }
        if (transform.localScale.y < 0.055f)
        {
            //scaleChange = -scaleChange;
            scaleChange = Vector3.one * 0.21f;
        }
        transform.localScale = Vector3.Lerp(transform.localScale, scaleChange, bounceSpeed * Time.deltaTime);

    }
}
