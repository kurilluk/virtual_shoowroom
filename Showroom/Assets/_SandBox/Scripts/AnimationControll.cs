using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationControll : MonoBehaviour
{
    public Animator anim;
   

    public void AnimStart (string animName)
    {
        anim.SetTrigger(animName);
    }
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //print("one");
            anim.SetTrigger("Start_Robot1");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {  
            anim.SetTrigger("Start_Robot2");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("Start_Robot3");
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

    public void StartRobot1()
    {
        //anim.SetBool("Start_Robot1", true);
        anim.SetTrigger("Start_Robot1");
    }

    public void StartRobot2()
    {
        anim.SetTrigger("Start_Robot2");
    }

    public void StartRobot3()
    {
        anim.SetTrigger("Start_Robot3");
    }


}
