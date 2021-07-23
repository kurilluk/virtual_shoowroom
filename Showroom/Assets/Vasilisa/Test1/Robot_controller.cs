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
            var _pos = transq.localPosition;    
            transq.localPosition = new Vector3(_pos.x + 0.1f, _pos.y, _pos.z);
        }

        
        if (Input.GetKeyDown(KeyCode.D))
        {
           transq.localPosition = Vector3.zero;
        }
        
    }
}
