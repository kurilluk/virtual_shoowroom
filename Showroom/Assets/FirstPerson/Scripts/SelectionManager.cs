﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] public Material highlightedMaterial;
    [SerializeField] public Material defaultMaterial;
    //[SerializeField] public Color highlightedColor;
    //[SerializeField] public Color defaultColor;
    //[SerializeField] public string selectableTag = "Selectable";

    [SerializeField] private LayerMask layerMask;

    private Transform _activeSelection;

    // Update is called once per frame
    void Update()
    {
        if (_activeSelection != null) 
        {
            var selectionRenderer = _activeSelection.GetComponent<Renderer>();
            //selectionRenderer.material.color = defaultColor;
            selectionRenderer.material = defaultMaterial;
            Debug.Log("The material changed to Default color." + defaultMaterial.ToString());
            _activeSelection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMask))
        {
            var selection = hitInfo.transform;

            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = highlightedMaterial;
                Debug.Log("Material changed to Highlighted color." + highlightedMaterial.ToString());

                if (Input.GetMouseButtonDown(0))
                {
                    var obj = selection.GetChild(0).gameObject;
                    obj.SetActive(!obj.activeInHierarchy);

                    //Debug.Log("Click to enable the Pop-up window now!");
                    //if (!selection.GetChild(0).gameObject.activeInHierarchy)
                    //{
                    //    selection.GetChild(0).gameObject.SetActive(true);
                    //}
                    //else
                    //{
                    //    selection.GetChild(0).gameObject.SetActive(false);
                    //}
                }
            }
            _activeSelection = selection;
 

        }
    }
}
