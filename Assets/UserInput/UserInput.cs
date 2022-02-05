// GENERATED AUTOMATICALLY FROM 'Assets/UserInput/UserInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @UserInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @UserInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""UserInput"",
    ""maps"": [
        {
            ""name"": ""PlayerInput"",
            ""id"": ""af446be3-1867-45ec-a879-db642063d013"",
            ""actions"": [
                {
                    ""name"": ""OnMouseLeftButtonClick"",
                    ""type"": ""Button"",
                    ""id"": ""9b6c6b00-1bce-4f3f-8702-b6ee22c089c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OnMouseRightButtonClick"",
                    ""type"": ""Button"",
                    ""id"": ""7a6379a1-82e1-4261-96fb-91c9f0559036"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OnMousePan"",
                    ""type"": ""PassThrough"",
                    ""id"": ""26c15669-cccd-4bbb-9a4d-c217a7e795d6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OnMouseZoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3350e9b6-166f-479e-a16c-3bc6a978ba0c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b7ef0801-125f-4f78-a8dd-4302f9554dda"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMouseLeftButtonClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c4e989b-8ebd-41e4-9309-aca54dfe2860"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMousePan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c008f79d-3d85-4013-8df3-a499886e9f51"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""Normalize(min=-1,max=1)"",
                    ""groups"": """",
                    ""action"": ""OnMouseZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b664aab2-10ab-4a99-9d99-e01a90d6ee3b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMouseRightButtonClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerInput
        m_PlayerInput = asset.FindActionMap("PlayerInput", throwIfNotFound: true);
        m_PlayerInput_OnMouseLeftButtonClick = m_PlayerInput.FindAction("OnMouseLeftButtonClick", throwIfNotFound: true);
        m_PlayerInput_OnMouseRightButtonClick = m_PlayerInput.FindAction("OnMouseRightButtonClick", throwIfNotFound: true);
        m_PlayerInput_OnMousePan = m_PlayerInput.FindAction("OnMousePan", throwIfNotFound: true);
        m_PlayerInput_OnMouseZoom = m_PlayerInput.FindAction("OnMouseZoom", throwIfNotFound: true);
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

    // PlayerInput
    private readonly InputActionMap m_PlayerInput;
    private IPlayerInputActions m_PlayerInputActionsCallbackInterface;
    private readonly InputAction m_PlayerInput_OnMouseLeftButtonClick;
    private readonly InputAction m_PlayerInput_OnMouseRightButtonClick;
    private readonly InputAction m_PlayerInput_OnMousePan;
    private readonly InputAction m_PlayerInput_OnMouseZoom;
    public struct PlayerInputActions
    {
        private @UserInput m_Wrapper;
        public PlayerInputActions(@UserInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @OnMouseLeftButtonClick => m_Wrapper.m_PlayerInput_OnMouseLeftButtonClick;
        public InputAction @OnMouseRightButtonClick => m_Wrapper.m_PlayerInput_OnMouseRightButtonClick;
        public InputAction @OnMousePan => m_Wrapper.m_PlayerInput_OnMousePan;
        public InputAction @OnMouseZoom => m_Wrapper.m_PlayerInput_OnMouseZoom;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInputActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInputActions instance)
        {
            if (m_Wrapper.m_PlayerInputActionsCallbackInterface != null)
            {
                @OnMouseLeftButtonClick.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnOnMouseLeftButtonClick;
                @OnMouseLeftButtonClick.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnOnMouseLeftButtonClick;
                @OnMouseLeftButtonClick.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnOnMouseLeftButtonClick;
                @OnMouseRightButtonClick.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnOnMouseRightButtonClick;
                @OnMouseRightButtonClick.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnOnMouseRightButtonClick;
                @OnMouseRightButtonClick.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnOnMouseRightButtonClick;
                @OnMousePan.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnOnMousePan;
                @OnMousePan.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnOnMousePan;
                @OnMousePan.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnOnMousePan;
                @OnMouseZoom.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnOnMouseZoom;
                @OnMouseZoom.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnOnMouseZoom;
                @OnMouseZoom.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnOnMouseZoom;
            }
            m_Wrapper.m_PlayerInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @OnMouseLeftButtonClick.started += instance.OnOnMouseLeftButtonClick;
                @OnMouseLeftButtonClick.performed += instance.OnOnMouseLeftButtonClick;
                @OnMouseLeftButtonClick.canceled += instance.OnOnMouseLeftButtonClick;
                @OnMouseRightButtonClick.started += instance.OnOnMouseRightButtonClick;
                @OnMouseRightButtonClick.performed += instance.OnOnMouseRightButtonClick;
                @OnMouseRightButtonClick.canceled += instance.OnOnMouseRightButtonClick;
                @OnMousePan.started += instance.OnOnMousePan;
                @OnMousePan.performed += instance.OnOnMousePan;
                @OnMousePan.canceled += instance.OnOnMousePan;
                @OnMouseZoom.started += instance.OnOnMouseZoom;
                @OnMouseZoom.performed += instance.OnOnMouseZoom;
                @OnMouseZoom.canceled += instance.OnOnMouseZoom;
            }
        }
    }
    public PlayerInputActions @PlayerInput => new PlayerInputActions(this);
    public interface IPlayerInputActions
    {
        void OnOnMouseLeftButtonClick(InputAction.CallbackContext context);
        void OnOnMouseRightButtonClick(InputAction.CallbackContext context);
        void OnOnMousePan(InputAction.CallbackContext context);
        void OnOnMouseZoom(InputAction.CallbackContext context);
    }
}
