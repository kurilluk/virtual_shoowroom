using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_controller : MonoBehaviour
{
    public Animator[] anims;
    public Transform transq;


  

  
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach (Animator anim in anims)
            {
                anim.SetTrigger("anim1");
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            foreach (var anim in anims)
            {
                anim.SetTrigger("anim2");    
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (var anim in anims)
            {
                anim.SetBool("anim3", true);    
            }
            
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (var anim in anims)
            {
                anim.SetBool("anim3", false);    
            }
            
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
           transq.localPosition = new Vector3(transq.localPosition.x + 0.1f, transq.localPosition.y, transq.localPosition.z);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
           transq.localPosition = Vector3.zero;
        }
        
        
    }
}
