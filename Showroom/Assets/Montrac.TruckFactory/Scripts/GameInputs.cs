// GENERATED AUTOMATICALLY FROM 'Assets/Montrac.TruckFactory/Scripts/GameInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputs"",
    ""maps"": [
        {
            ""name"": ""Cart"",
            ""id"": ""74f13029-89d2-4430-8f80-5d115a174216"",
            ""actions"": [
                {
                    ""name"": ""Initialize"",
                    ""type"": ""Button"",
                    ""id"": ""3dbbf0cc-f140-4cdd-a54f-3a375f4f3eb1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""a2ee355a-85af-4e39-b9dd-adcd5c255b57"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6f5457a0-e559-4a11-9333-2a21a964861d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37beed7e-67ae-4911-a48f-f60fa98f7294"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Initialize"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Cart
        m_Cart = asset.FindActionMap("Cart", throwIfNotFound: true);
        m_Cart_Initialize = m_Cart.FindAction("Initialize", throwIfNotFound: true);
        m_Cart_Move = m_Cart.FindAction("Move", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Cart
    private readonly InputActionMap m_Cart;
    private ICartActions m_CartActionsCallbackInterface;
    private readonly InputAction m_Cart_Initialize;
    private readonly InputAction m_Cart_Move;
    public struct CartActions
    {
        private @GameInputs m_Wrapper;
        public CartActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Initialize => m_Wrapper.m_Cart_Initialize;
        public InputAction @Move => m_Wrapper.m_Cart_Move;
        public InputActionMap Get() { return m_Wrapper.m_Cart; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CartActions set) { return set.Get(); }
        public void SetCallbacks(ICartActions instance)
        {
            if (m_Wrapper.m_CartActionsCallbackInterface != null)
            {
                @Initialize.started -= m_Wrapper.m_CartActionsCallbackInterface.OnInitialize;
                @Initialize.performed -= m_Wrapper.m_CartActionsCallbackInterface.OnInitialize;
                @Initialize.canceled -= m_Wrapper.m_CartActionsCallbackInterface.OnInitialize;
                @Move.started -= m_Wrapper.m_CartActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CartActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CartActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_CartActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Initialize.started += instance.OnInitialize;
                @Initialize.performed += instance.OnInitialize;
                @Initialize.canceled += instance.OnInitialize;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public CartActions @Cart => new CartActions(this);
    public interface ICartActions
    {
        void OnInitialize(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
