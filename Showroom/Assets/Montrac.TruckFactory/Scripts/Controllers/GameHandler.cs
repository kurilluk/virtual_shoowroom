using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class GameHandler : MonoBehaviour
{
    private GameInputs _inputs;
    public Transform dynamicLayer;  // TODO: Create on run/if doesn't exist

    public Rail initRail;

    public Transform pf_Cart; // Prefab
    private Transform in_Cart; // Instance object
    private Cart cm_Cart; // Component from instance

    public Transform in_Rail;

    private void Awake()
    {
        _inputs = new GameInputs();
        _inputs.Game.Enable();
        _inputs.Game.Initialize.started += InitializeCart;
        _inputs.Game.Move.started += MoveCart;
        _inputs.Game.Switch.started += RotateSwitch;
    }

    private void RotateSwitch(InputAction.CallbackContext obj)
    {
        // if (!in_Rail)
        //     return;
        // var cm_SA = in_Rail.GetChild(0).GetComponent<SwitchAnimator>();
        // cm_SA.Rotate();

        if (cm_Cart == null)
        {
            Debug.Log("No Cart instance is in the game yet. Press SPACE key to create one.");
            return;
        }
        if (!cm_Cart.currentRail.isInteractive)
        {
            Debug.Log("No interactions with current rail are possible. Please move forward by pressing UP ARROW key.");
            return;
        }

        cm_Cart.currentRail.Interaction();



    }

    private void MoveCart(InputAction.CallbackContext context)
    {
        if (!in_Cart)
        {
            Debug.Log("No Cart instance is in the game yet. Press SPACE key to create one.");
            return;
        }
            
        //Debug.Log(context);
        //cm_Cart.Move(((int)((KeyControl)context.control).keyCode) != 63);
        //cm_Cart.Move();
        print("I'm coming!");
        cm_Cart.Move(cm_Cart.currentRail.Movement);
    }

    private void InitializeCart(InputAction.CallbackContext obj)
    {
        print("Great! You created your first Cart. Now you can control it with S and UP keys.");
        in_Cart = Instantiate(pf_Cart, initRail.StartPoint, Quaternion.identity, dynamicLayer);
        cm_Cart = in_Cart.GetComponent<Cart>();
        initRail.AddCart(cm_Cart);
        //_inputs.Cart.Move.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        //print(Screen.currentResolution);
        print("Hi, welcome in the game mode. Here you can control a Cart and Rails by pressing UP ARROW (movement) and S (interaction) keys.");
        //Transform in_Cart = Instantiate(pf_Cart, new Vector3(1.2f, 0.85f, -4), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
