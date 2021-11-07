using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class GameHandler : MonoBehaviour
{
    public Transform pfCart;
    public Transform origin;

    private GameInputs _inputs;
    private Transform cart;
    private Cart cart_class;

    private void Awake()
    {
        _inputs = new GameInputs();
        _inputs.Enable();
        _inputs.Cart.Initialize.started += InitializeCart;
        _inputs.Cart.Move.started += MoveCart;
        //_inputs.Cart.Move.Disable();

    }

    private void MoveCart(InputAction.CallbackContext context)
    {
        if (!cart)
            return;
        Debug.Log(context);
        cart_class.Move(((int)((KeyControl)context.control).keyCode) != 63);
    }

    private void InitializeCart(InputAction.CallbackContext obj)
    {
        cart = Instantiate(pfCart, origin);
        cart_class = cart.GetComponent<Cart>();
        //_inputs.Cart.Move.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        print(Screen.currentResolution);
        //Transform cart = Instantiate(pfCart, new Vector3(1.2f, 0.85f, -4), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
