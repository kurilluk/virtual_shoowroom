using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenPathway : MonoBehaviour
{
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        List<GameObject> childObjects = new List<GameObject>();
        lineRenderer = GetComponent<LineRenderer>();

        foreach (Transform child in allChildren)
        {
            childObjects.Add(child.gameObject);
        }

        lineRenderer.positionCount = childObjects.Count;
        Vector3[] positions = new Vector3[] { };
        Vector3 pathPoint = new Vector3(0, 0, 0);
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(childObjects[i].transform.position.x, childObjects[i].transform.position.y, childObjects[i].transform.position.z));
        }

        DrawPath(positions);
    }
    void DrawPath(Vector3[] vertexPositions)
    {
        lineRenderer.positionCount = 3;
        lineRenderer.SetPositions(vertexPositions);
    }
}