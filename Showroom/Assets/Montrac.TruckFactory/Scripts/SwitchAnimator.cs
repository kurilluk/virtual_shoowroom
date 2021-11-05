using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimator: MonoBehaviour
{
    public float A_state;
    public float B_state;
    public float speed = 1f;
    [SerializeField]
    private AnimationCurve _function;
    // starting value for the Lerp
    static float t = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("From:" + A_state + " to:" + B_state);
        
    }

    // Update is called once per frame
    void Update()
    {
        // animate the position of the game object...
        float rotation = Mathf.Lerp(A_state, B_state, _function.Evaluate(t));
        //Debug.Log("Rotation:" + rotation);
        //transform.Rotate(Vector3.up,rotation);

        transform.rotation = Quaternion.Euler(0, rotation, 0);

        // .. and increase the t interpolater
        t += 0.5f * Time.deltaTime * speed;
       // Debug.Log("t:" + t);

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = A_state;
            A_state = B_state;
            B_state = temp;
            t = 0.0f;
        }
    }
}
