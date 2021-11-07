using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{

    public float speed = 0.5f;
    public Rail currentRail;

    Animator _anim;
    int up_110 = Animator.StringToHash("Move_110");

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void Move()//Vector3 position)
    { }

        public void Move(bool turn)//Vector3 position)
    {
        if (turn)
            _anim.Play("Turn_left");
        else
            _anim.Play(up_110);

        //StartCoroutine(MoveCart());

        //transform.position = position;
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);     
    }

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

    IEnumerator MoveCart()
    {
        //_anim.Play(up_110);

        float counter = 0;
        float waitTime = _anim.GetCurrentAnimatorStateInfo(0).length;

        //Now, Wait until the current state is done playing
        while (counter < (waitTime))
        {
            counter += Time.deltaTime;
            Debug.Log("Animation");
            yield return null;
        }
        Debug.Log("Ended");

        while (_anim.GetCurrentAnimatorStateInfo(0).IsName("Move_110") &&
        _anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        { }
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        /// Actualize data - position/possibilities/...
        /// Wait for input
        yield return null;
    }
}
