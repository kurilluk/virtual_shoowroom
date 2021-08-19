using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            HideInfoSphere();
        }
        
    }

    public void HideInfoSphere()
    {
        Debug.Log("Hiding this InfoSphere." + this.ToString());
        this.transform.GetChild(0).gameObject.SetActive(false);
    }
}
