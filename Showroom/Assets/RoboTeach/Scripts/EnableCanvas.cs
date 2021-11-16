using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCanvas : MonoBehaviour
{
    public Canvas canvas;

    private void Awake()
    {
        canvas.enabled = true;
    }


}
