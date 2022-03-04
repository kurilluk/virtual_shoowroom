﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] public Material highlightedMaterial;
    [SerializeField] public Material defaultMaterial;

    [SerializeField] public Material arrowHighlightedMaterial;
    [SerializeField] public Material arrowDefaultMaterial;

    [SerializeField] private LayerMask layerMask;

    private Transform _activeSelection;

    // Declare a delegate using Action
    public static event Action arrowIncrease;
    public static event Action arrowDecrease;

    void Update()
    {
        if (_activeSelection != null) 
        {
            var selectionRenderer = _activeSelection.GetComponent<Renderer>();
 
            if (_activeSelection.transform.tag == "Arrows")
            {
                selectionRenderer.material = arrowDefaultMaterial;
            }
            else
            {
                selectionRenderer.material = defaultMaterial;
            }
            _activeSelection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMask))
        {
            var selection = hitInfo.transform;
            Debug.Log(hitInfo.transform.name);

            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                if (hitInfo.transform.tag == "Arrows")
                {
                    selectionRenderer.material = arrowHighlightedMaterial;
                    Debug.Log("Move the arm please.");
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (hitInfo.transform.name == "Arrow-Plus")
                            arrowIncrease?.Invoke();
                        else if (hitInfo.transform.name == "Arrow-Minus")
                            arrowDecrease?.Invoke();
                    }
                }
                else
                {
                    selectionRenderer.material = highlightedMaterial;

                    //Show the first child of the selected object
                    if (Input.GetMouseButtonDown(0))
                    {
                        var obj = selection.GetChild(0).gameObject;
                        obj.SetActive(!obj.activeInHierarchy);
                    }
                }


            }
            _activeSelection = selection;
 

        }
    }
}
