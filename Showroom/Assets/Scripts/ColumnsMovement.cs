using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnsMovement : MonoBehaviour
{
    public GameObject sloup;

    private bool shouldLerp = false;

    public float timeStartedLerping;
    public float lerpTime;

    public Vector3 endPosition;
    public Vector3 startPosition;


    private void StartLerping()
    {
        timeStartedLerping = Time.time;

        shouldLerp = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        StartLerping();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (shouldLerp)
        //Input.GetKey("q")
        {
            shouldLerp = true;
                        
            transform.position = Lerp(startPosition, endPosition, timeStartedLerping, lerpTime);

        }
        
    }

    public Vector3 Lerp(Vector3 start, Vector3 end, float timeStartedLerping, float lerpTime = 1)
    {
        float timeSinceStarted = Time.time - timeStartedLerping;

        float percentageComplete = timeSinceStarted / lerpTime;

        var result = Vector3.Lerp(start, end, percentageComplete);

        return result;
    }
}
