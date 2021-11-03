using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{

    public float speed = 0.5f;
    public Rail currentRail;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(currentRail != null)
        // {
        //     float distance = currentRail.Distance(transform.position);
        //     Debug.Log("Distance: "+ distance);
        //     if(distance > 0.01f)
        //     Move();
        //     else
        //     currentRail = currentRail.nextRail;
        // }
  
    }

    public void Move()//Vector3 position)
    {
        //transform.position = position;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);     
    }
}
