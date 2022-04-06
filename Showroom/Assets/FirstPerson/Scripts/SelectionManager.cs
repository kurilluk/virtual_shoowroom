using System.Collections;
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

    [SerializeField] private float arrowRotationSpeed = 5f;
    public GameObject robot;
    private Transform _activeSelection;

    // Declare a delegate using Action
    public static event Action<int, float> arrowRotate;

    //private void Start()
    //{
    //    //TODO: Define default materials for all the child objects of KUKA-MoveJ (Cross scene refference!!! - MegaDIRTY !!!)
    //    List<Transform> allChildren = new List<Transform>();
    //    foreach (Transform child in robot.transform)
    //    {
    //        var defaultRenderer = child.gameObject.GetComponent<Renderer>();
    //        if (defaultRenderer != null)
    //        {
    //            defaultMaterial = defaultRenderer.material;
    //            Debug.Log(defaultMaterial.name);
    //        }

    //    }
    //}

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
            //Debug.Log(hitInfo.transform.name);

            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                if (hitInfo.transform.tag == "Arrows")
                {
                    selectionRenderer.material = arrowHighlightedMaterial;
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (hitInfo.transform.name == "Arrow-Plus")
                        {
                            //arrowIncrease?.Invoke();
                            switch (hitInfo.transform.parent.parent.name)
                            {
                                case "Arm0":
                                    arrowRotate?.Invoke(0, arrowRotationSpeed);
                                    break;
                                case "Arm1":
                                    arrowRotate?.Invoke(1, arrowRotationSpeed);
                                    break;
                                case "Arm2":
                                    arrowRotate?.Invoke(2, arrowRotationSpeed);
                                    break;
                                case "Arm3":
                                    arrowRotate?.Invoke(3, arrowRotationSpeed);
                                    break;
                                case "Arm4":
                                    arrowRotate?.Invoke(4, arrowRotationSpeed);
                                    break;
                                case "Arm5":
                                    arrowRotate?.Invoke(5, arrowRotationSpeed);
                                    break;
                                case "Tool":
                                    arrowRotate?.Invoke(5, arrowRotationSpeed);
                                    break;
                                default:
                                    break;
                            }
                        }
                        else if (hitInfo.transform.name == "Arrow-Minus")
                        {
                            switch (hitInfo.transform.parent.parent.name)
                            {
                                case "Arm0":
                                    arrowRotate?.Invoke(0, -arrowRotationSpeed);
                                    break;
                                case "Arm1":
                                    arrowRotate?.Invoke(1, -arrowRotationSpeed);
                                    break;
                                case "Arm2":
                                    arrowRotate?.Invoke(2, -arrowRotationSpeed);
                                    break;
                                case "Arm3":
                                    arrowRotate?.Invoke(3, -arrowRotationSpeed);
                                    break;
                                case "Arm4":
                                    arrowRotate?.Invoke(4, -arrowRotationSpeed);
                                    break;
                                case "Arm5":
                                    arrowRotate?.Invoke(5, -arrowRotationSpeed);
                                    break;
                                case "Tool":
                                    arrowRotate?.Invoke(5, -arrowRotationSpeed);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    selectionRenderer.material = highlightedMaterial;

                    var obj = selection.GetChild(0).gameObject;

                    //Show the first child of the selected object
                    if (Input.GetMouseButtonDown(0))
                    {
                        //var obj = selection.GetChild(0).gameObject;

                        
                        if (hitInfo.transform.name == "Tool")
                        {
                            obj = selection.parent.GetChild(0).gameObject;
                        }
                        else
                        {
                            obj = selection.GetChild(0).gameObject;
                        }

                        obj.SetActive(!obj.activeInHierarchy);

                    }
                }


            }
            _activeSelection = selection;
        }
    }
}
