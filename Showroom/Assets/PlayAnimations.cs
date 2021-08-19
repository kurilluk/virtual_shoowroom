using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimations : MonoBehaviour
{
    public Animation anim;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //Animator animator = this.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            animator.Play("Anim_Robot1");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            animator.Play("Anim_Robot2");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            animator.Play("Anim_Robot3");
        }
    }
}
