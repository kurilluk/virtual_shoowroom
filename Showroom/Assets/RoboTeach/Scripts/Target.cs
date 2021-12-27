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
        levelPositions = positions;
        ResetIndex();
        MoveMe(levelPositions[acturalTargetIndex]);
    }

    private void ResetIndex() 
    {
        acturalTargetIndex = 0;
    }

    private void EnableMe() 
    {
        targetGO.SetActive(true);
        StartCoroutine(AnimateMe(1f));
    }

    IEnumerator AnimateMe(float desiredScale) 
    {
        for (float f = 0; f<=1; f+=0.1f ) 
        {
            targetGO.transform.localScale = new Vector3(1f,1f,1f) * desiredScale * f;
            yield return new WaitForSeconds(0.1f);
        }

        //yield return null;
    }

    private void MoveMe(Vector3 moveHere) 
    {
        this.transform.position = moveHere;
        // TODO: Add animation 
    }

    private void TargetHit() 
    {
        AnimateMe(0.001f);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("You've hit the target!");
        TargetHit();
        acturalTargetIndex++;
        if (acturalTargetIndex >= levelPositions.Length)
        {
            VictoryEvent.Invoke();
            ResetIndex();
        }
        else 
        {
            MoveMe(levelPositions[acturalTargetIndex]);
            EnableMe();
        }
    }
}
