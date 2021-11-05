using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private void MoveCart(InputAction.CallbackContext obj)
    {
        if (cart == null)
            return;
       cart_class.Move();
        
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
        //Transform cart = Instantiate(pfCart, new Vector3(1.2f, 0.85f, -4), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
