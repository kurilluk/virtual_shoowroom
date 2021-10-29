using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KukaController2 : MonoBehaviour
{
    public Animator anim;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //print("one");
            anim.SetTrigger("anim1");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {  
            anim.SetTrigger("anim2");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("anim3");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetBool("anim4", true);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            anim.SetBool("anim4", false);
        }

        
    
        
    }
}
