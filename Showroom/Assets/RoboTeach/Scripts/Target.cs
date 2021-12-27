using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Target : MonoBehaviour
{
    [SerializeField] UnityEvent VictoryEvent;

    public Vector3[] levelPositions;
    private int acturalTargetIndex = 0;

    public GameObject targetGO;

    private void Awake()
    {
        InitializeMe(levelPositions);
    }
    private void Start()
    {
        EnableMe();
    }

    public void InitializeMe(Vector3[] positions) 
    {
        Debug.Log("Initialized the Target.");
        levelPositions = positions;
        ResetIndex();
        MoveMe(levelPositions[0]);
    }

    private void ResetIndex() 
    {
        Debug.Log("The Index has been reset.");
        acturalTargetIndex = 0;
    }

    private void EnableMe() 
    {
        Debug.Log("Target just got Enabled.");
        targetGO.SetActive(true);
        StartCoroutine(Grow());
    }

    IEnumerator Grow() 
    {
        for (float f = 0; f<=1; f+=0.05f ) 
        {
            StopCoroutine(Shrink());
            Debug.Log("Growing animation frame: "+ f.ToString());
            targetGO.transform.localScale = new Vector3(1f,1f,1f) * f;
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator Shrink()
    {
        StopCoroutine(Grow());
        for (float f = 1; f >= 0.0001; f -= 0.05f)
        {
            Debug.Log("Shrinking animation frame: " + f.ToString());
            targetGO.transform.localScale = new Vector3(1f, 1f, 1f) * f;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void MoveMe(Vector3 moveHere) 
    {
        Debug.Log("Target moved to a new position: " + moveHere.ToString());
        this.transform.position = moveHere;
        // TODO: Add animation 
    }

    private void TargetHit() 
    {
        StopCoroutine(Grow());
        StartCoroutine(Shrink());
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You've hit the target!");
        TargetHit();
        acturalTargetIndex++;
        if (acturalTargetIndex >= levelPositions.Length)
        {
            VictoryEvent.Invoke();
            Debug.Log("You've won!");
            ResetIndex();
        }
        else 
        {
            MoveMe(levelPositions[acturalTargetIndex]);
            EnableMe();
        }
    }
}
