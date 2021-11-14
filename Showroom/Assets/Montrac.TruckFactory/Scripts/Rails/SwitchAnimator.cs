using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimator : MonoBehaviour
{
    [SerializeField] private float A_state;
    [SerializeField] private float B_state;
    [SerializeField] private AnimationCurve _function;
    // starting value for the Lerp
    [SerializeField] private float stepSize = 0.5f;
    static float _actual = 0.0f;
    static bool _switch = false;
    private float direction = 1; // can be -1 and 1
    private bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("From:" + A_state + " to:" + B_state);

    }

    public void Rotate()
    {
        StartCoroutine("RotateAnim");
    }

    IEnumerator RotateAnim()
    {
        isMoving = true;

        while (isMoving)
        {
            _actual += stepSize * direction * Time.deltaTime;

            if (_actual > 1.0f)
            {
                _actual = 1.0f;
                _switch = true;
                direction = -1;
                isMoving = false;
            }
            else if (_actual < 0.0f)
            {
                _actual = 0.0f;
                _switch = false;
                direction = 1;
                isMoving = false;
            }

            float rotation = Mathf.Lerp(A_state, B_state, _function.Evaluate(_actual));
            transform.rotation = Quaternion.Euler(0, rotation, 0);

            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // // animate the position of the game object...
        // float rotation = Mathf.Lerp(A_state, B_state, _function.Evaluate(t));
        // //Debug.Log("Rotation:" + rotation);
        // //transform.Rotate(Vector3.up,rotation);

        // transform.rotation = Quaternion.Euler(0, rotation, 0);

        // // .. and increase the t interpolater
        // t += 0.5f * Time.deltaTime * speed;
        // // Debug.Log("t:" + t);

        // // now check if the interpolator has reached 1.0
        // // and swap maximum and minimum so game object moves
        // // in the opposite direction.
        // if (t > 1.0f)
        // {
        //     float temp = A_state;
        //     A_state = B_state;
        //     B_state = temp;
        //     t = 0.0f;
        // }
    }
}
