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
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b11dc1f9-43c2-4239-b961-53bbfcaddd63"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseLBClick"",
                    ""type"": ""Button"",
                    ""id"": ""9b6c6b00-1bce-4f3f-8702-b6ee22c089c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseRBClick"",
                    ""type"": ""Button"",
                    ""id"": ""7a6379a1-82e1-4261-96fb-91c9f0559036"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraPan"",
                    ""type"": ""Button"",
                    ""id"": ""ac61d8af-1a7c-4fec-9813-647f3eebf8e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraRotation"",
                    ""type"": ""Button"",
                    ""id"": ""bce85139-affb-4f22-8c82-aa753a25b2db"",
                    ""expectedControlType"": ""Button"",
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
                    ""action"": ""MouseLBClick"",
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
                    ""action"": ""MouseRBClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""15ac121d-1ccc-4cc1-aa88-e830135ff4ef"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraPan"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""472369e1-81df-42b9-8cb3-1cf46749779f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraPan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ef6f7e1e-ffca-48c2-968a-f7c1bb298fcc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraPan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""36a7bd15-f33d-4c01-94a8-11499adf6009"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraPan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""69199bbc-fc3e-430b-b811-e946beea3cbe"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraPan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""c781e4e4-48af-4084-9109-ad5dbbda1588"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraPan"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3326d13c-9f2e-4683-bebc-3926f0463cec"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraPan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8cc29a16-c47b-487e-a12a-5d0717ee0a6a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraPan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a970d5d7-22aa-421c-b157-8085762e2724"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraPan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1bc0fcf4-2515-4ee1-98cd-861a06a62f5d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraPan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""1a4728ae-8e1a-4597-a217-7a27a696a6ab"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraRotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""028600f4-6a8e-498e-8171-ecb645e65fbb"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""af5a7e91-fcf8-4b7b-a9ec-413297d66cc5"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6eaf7aba-ef49-418e-b51a-b578912c7516"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
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
        m_PlayerInput_MousePosition = m_PlayerInput.FindAction("MousePosition", throwIfNotFound: true);
        m_PlayerInput_MouseLBClick = m_PlayerInput.FindAction("MouseLBClick", throwIfNotFound: true);
        m_PlayerInput_MouseRBClick = m_PlayerInput.FindAction("MouseRBClick", throwIfNotFound: true);
        m_PlayerInput_CameraPan = m_PlayerInput.FindAction("CameraPan", throwIfNotFound: true);
        m_PlayerInput_CameraRotation = m_PlayerInput.FindAction("CameraRotation", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerInput_MousePosition;
    private readonly InputAction m_PlayerInput_MouseLBClick;
    private readonly InputAction m_PlayerInput_MouseRBClick;
    private readonly InputAction m_PlayerInput_CameraPan;
    private readonly InputAction m_PlayerInput_CameraRotation;
    public struct PlayerInputActions
    {
        private @UserInput m_Wrapper;
        public PlayerInputActions(@UserInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_PlayerInput_MousePosition;
        public InputAction @MouseLBClick => m_Wrapper.m_PlayerInput_MouseLBClick;
        public InputAction @MouseRBClick => m_Wrapper.m_PlayerInput_MouseRBClick;
        public InputAction @CameraPan => m_Wrapper.m_PlayerInput_CameraPan;
        public InputAction @CameraRotation => m_Wrapper.m_PlayerInput_CameraRotation;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInputActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInputActions instance)
        {
            if (m_Wrapper.m_PlayerInputActionsCallbackInterface != null)
            {
                @MousePosition.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMousePosition;
                @MouseLBClick.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMouseLBClick;
                @MouseLBClick.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMouseLBClick;
                @MouseLBClick.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMouseLBClick;
                @MouseRBClick.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMouseRBClick;
                @MouseRBClick.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMouseRBClick;
                @MouseRBClick.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMouseRBClick;
                @CameraPan.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnCameraPan;
                @CameraPan.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnCameraPan;
                @CameraPan.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnCameraPan;
                @CameraRotation.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnCameraRotation;
                @CameraRotation.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnCameraRotation;
                @CameraRotation.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnCameraRotation;
            }
            m_Wrapper.m_PlayerInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @MouseLBClick.started += instance.OnMouseLBClick;
                @MouseLBClick.performed += instance.OnMouseLBClick;
                @MouseLBClick.canceled += instance.OnMouseLBClick;
                @MouseRBClick.started += instance.OnMouseRBClick;
                @MouseRBClick.performed += instance.OnMouseRBClick;
                @MouseRBClick.canceled += instance.OnMouseRBClick;
                @CameraPan.started += instance.OnCameraPan;
                @CameraPan.performed += instance.OnCameraPan;
                @CameraPan.canceled += instance.OnCameraPan;
                @CameraRotation.started += instance.OnCameraRotation;
                @CameraRotation.performed += instance.OnCameraRotation;
                @CameraRotation.canceled += instance.OnCameraRotation;
            }
        }
    }
    public PlayerInputActions @PlayerInput => new PlayerInputActions(this);
    public interface IPlayerInputActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMouseLBClick(InputAction.CallbackContext context);
        void OnMouseRBClick(InputAction.CallbackContext context);
        void OnCameraPan(InputAction.CallbackContext context);
        void OnCameraRotation(InputAction.CallbackContext context);
    }
}
