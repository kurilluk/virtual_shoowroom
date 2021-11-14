using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCoin : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        gameObject.SetActive(false);
    }
}
