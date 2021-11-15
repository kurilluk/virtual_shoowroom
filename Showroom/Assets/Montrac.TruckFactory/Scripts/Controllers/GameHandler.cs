using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class GameHandler : MonoBehaviour
{
    public Transform pfCart;
    public Transform dynamicLayer;  // TODO: Create on run/if doesn't exist

    public Rail initRail;

    private GameInputs _inputs;
    private Transform cart;
    public Cart cart_class;

    private void Awake()
    {
        _inputs = new GameInputs();
        _inputs.Game.Enable();
        _inputs.Game.Initialize.started += InitializeCart;
        _inputs.Game.Move.started += MoveCart;
        //_inputs.Cart.Move.Disable();
    }

    private void MoveCart(InputAction.CallbackContext context)
    {
        if (!cart_class)
            return;
        Debug.Log(context);
        cart_class.Move(((int)((KeyControl)context.control).keyCode) != 63);
        //cart_class.Move();
    }

    private void InitializeCart(InputAction.CallbackContext obj)
    {
        cart = Instantiate(pfCart, initRail.StartPoint, Quaternion.identity, dynamicLayer);
        cart_class = cart.GetComponent<Cart>();
        initRail.AddCart(cart_class);
        //_inputs.Cart.Move.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        print(Screen.currentResolution);
        //Transform cart = Instantiate(pfCart, new Vector3(1.2f, 0.85f, -4), Quaternion.identity);

        if (initRail != null && cart_class != null)
        {
            initRail.AddCart(cart_class);
            Debug.Log("Cart initialized.");
        }
    }

    // // Update is called once per frame
    // void Update()
    // {

    // }
}
