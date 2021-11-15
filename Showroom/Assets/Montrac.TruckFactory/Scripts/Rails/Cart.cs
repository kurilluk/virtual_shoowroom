﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    public float speed = 0.5f;
    public Rail currentRail;

    Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void Move(int anim)
    {
        // TODO: Check if exist
        _anim.Play(anim);
    }

    public void Move(bool turn)//Vector3 position)
    {
        if (turn)
            _anim.Play(Movement.TR_Left);
        else
            _anim.Play(Movement.FW_110);

        //StartCoroutine(MoveCart());

        //transform.position = position;
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);     
    }

    public void Move()
    {
        _anim.Play(currentRail.Movement);  //TODO: get type of movement from curent rail
        //StartCoroutine(RunAnimation(up_110)); // Coroutine is not needed...
    }

    public void AfterAnimation()
    {
        //Check distance from rail end point
        var endDistance = Vector3.Distance(transform.position, currentRail.EndPoint);
        //Debug.Log("Distance:" + endDistance);

        if (endDistance < 0.1)
        {
            //Change next rail to currant rail by registration
            currentRail.NextRail.AddCart(this);
            print("Perfect, your Cart is moved on a new poition. You can interact with the new "+ currentRail.transform.name +" now.");
            if (!currentRail.isInteractive)
            {
                print("There are no interaction on this rail, therefore I am moving you futher.");
                Move();
            }
        }
        else
            Debug.Log("LostCart! Distance from end point is more than trashold.");


    }

    public static class Movement
    {
        public static int FW_110 = Animator.StringToHash("FW_110");
        public static int FW_Switch = Animator.StringToHash("FW_Switch");
        public static int TR_Left = Animator.StringToHash("TR_Left");
    }

    //IEnumerator RunAnimation(int anim)
    //{
    //    //TODO: check if card have this anim

    //    _anim.Play(anim);
    //    while (false)
    //    {
    //        var time = _anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    //        var name = _anim.GetCurrentAnimatorStateInfo(0);
    //        if (time < 1f)
    //            Debug.Log("Animation "+ name +": " + time*100 + "%");
    //        else
    //            Debug.Log("Ended at " + time * 100 + "%");

    //        yield return null;
    //    }

    //    Debug.Log("CART: Animation Ended");

    //    //float counter = 0;
    //    //float waitTime = _anim.GetCurrentAnimatorStateInfo(0).length;

    //    ////Now, Wait until the current state is done playing
    //    //while (counter < (waitTime))
    //    //{
    //    //    counter += Time.deltaTime;
    //    //    Debug.Log("Animation");
    //    //    yield return null;
    //    //}
    //    //Debug.Log("Ended");

    //    //while (_anim.GetCurrentAnimatorStateInfo(0).IsName("Move_110") &&
    //    //_anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
    //    //{ }
    //}

    /// Pseudo code
    /// 
    /// check position and possibilities - get object of collision/rail object
    /// 
    /// enable controls and wait for user input
    /// 
    /// check if user comand is possible to perform (possibility to make users mistakes - learning process) 
    /// 
    /// perform action - disable controls
    /// 

    //private void OnTriggerEnter(Collider collision)
    //{
    //    Debug.Log("Collision entered");
    //}

    // private void OnTriggerStay(Collider other)
    // {
    //     Debug.Log("Still here");
    // }


    // private void OnTriggerExit(Collider other)
    // {
    //     Debug.Log("Exit from collision");
    // }

    // //private IEnumerator OnTriggerEnter(Collider collision)
    // //{
    // //    /// Actualize data - position/possibilities/...
    // //    /// Wait for input
    // //    Debug.Log("Collision entered: " + collision);
    // //    yield return null;
    // //}

    // private void OnTriggerEnter(Collider other)
    // {

    // }
}
