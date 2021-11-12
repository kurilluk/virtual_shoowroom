using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonBuster : MonoBehaviour
{
    private GameObject Baloon;
    //private Collider BaloonCollider = this.GetComponent<Collider>();  


    void OnCollisionEnter(Collision other)
    {
        Debug.Log("The needle colided with baloon");
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        List<GameObject> childObjects = new List<GameObject>();
        
        foreach (Transform child in allChildren)
        {
            childObjects.Add(child.gameObject);
            Debug.Log("Bursting the Baloon using Robotic needle now.");
            child.gameObject.SetActive(false);
        }
        
    }
}
