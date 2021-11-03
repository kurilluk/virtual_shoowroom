using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField] private float bounceSpeed = 2f;
    [SerializeField] float maxSize = 0.21f;
    [SerializeField] float minSize = 0.05f;
    [SerializeField] float tolerance = 0.1f;

    //private float speed = 1f;
    private Vector3 scaleChange;
    
    // Start is called before the first frame update
    void Awake()
    {
        scaleChange = Vector3.one * maxSize;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(transform.localScale.y);
        //Very simple bouncing using LERP on scale of the object transform...
        if (transform.localScale.y > maxSize - tolerance)
        {
            scaleChange = Vector3.one * minSize;
        }
        if (transform.localScale.y < minSize + tolerance)
        {
            //scaleChange = -scaleChange;
            scaleChange = Vector3.one * maxSize;
        }
        transform.localScale = Vector3.Lerp(transform.localScale, scaleChange, bounceSpeed * Time.deltaTime);

    }
}
