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
            ""name"": ""Game"",
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
                },
                {
                    ""name"": ""Turn"",
                    ""type"": ""Button"",
                    ""id"": ""584e4cde-7aac-4a9b-a671-7b8ac3804d2e"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""e3c83647-2855-4e52-a3e1-9eef7cd1b560"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4eb9e5c7-02ec-4dca-a6fd-93628a274f9d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Initialize = m_Game.FindAction("Initialize", throwIfNotFound: true);
        m_Game_Move = m_Game.FindAction("Move", throwIfNotFound: true);
        m_Game_Turn = m_Game.FindAction("Turn", throwIfNotFound: true);
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

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Initialize;
    private readonly InputAction m_Game_Move;
    private readonly InputAction m_Game_Turn;
    public struct GameActions
    {
        private @GameInputs m_Wrapper;
        public GameActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Initialize => m_Wrapper.m_Game_Initialize;
        public InputAction @Move => m_Wrapper.m_Game_Move;
        public InputAction @Turn => m_Wrapper.m_Game_Turn;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Initialize.started -= m_Wrapper.m_GameActionsCallbackInterface.OnInitialize;
                @Initialize.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnInitialize;
                @Initialize.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnInitialize;
                @Move.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMove;
                @Turn.started -= m_Wrapper.m_GameActionsCallbackInterface.OnTurn;
                @Turn.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnTurn;
                @Turn.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnTurn;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Initialize.started += instance.OnInitialize;
                @Initialize.performed += instance.OnInitialize;
                @Initialize.canceled += instance.OnInitialize;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Turn.started += instance.OnTurn;
                @Turn.performed += instance.OnTurn;
                @Turn.canceled += instance.OnTurn;
            }
        }
    }
    public GameActions @Game => new GameActions(this);
    public interface IGameActions
    {
        void OnInitialize(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnTurn(InputAction.CallbackContext context);
    }
}
