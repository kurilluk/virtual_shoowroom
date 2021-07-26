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

            this.transform.Rotate(Vector3.up, 10);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            //too fast
            //this.transform.Rotate(Vector3.up, 120);

            this.transform.Rotate(Vector3.up, Mathf.Lerp(0f, 120f, 20f * Time.deltaTime));
        }


    }
}
