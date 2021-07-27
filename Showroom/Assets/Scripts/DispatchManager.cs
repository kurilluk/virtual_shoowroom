using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispatchManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            //too fast
            //this.transform.Rotate(Vector3.up, 120);

            this.transform.Rotate(Vector3.up, -1);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            //too fast
            //this.transform.Rotate(Vector3.up, 120);
            StartCoroutine("RotateDispatch");

            
            //this.transform.Rotate(Vector3.up, Mathf.Lerp(0f, 120f, t));
            
        }

        //It's not working, the coroutine couldn't be started
        IEnumerator RotateDispatch()
        {
            float t = 0f;
            Debug.Log(t);
            this.transform.Rotate(Vector3.up, Mathf.Lerp(0f, 120f, t));
            t += 0.2f;
            yield return new WaitForSeconds(0.2f);
        }

    }
}
