// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Services/InputService/UserInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Game0
{
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
                    ""name"": ""CameraRotation"",
                    ""type"": ""Button"",
                    ""id"": ""bce85139-affb-4f22-8c82-aa753a25b2db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraZoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c4cd11d2-7130-413d-a469-05d488e5cec9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Moving"",
                    ""type"": ""Button"",
                    ""id"": ""ac61d8af-1a7c-4fec-9813-647f3eebf8e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Space"",
                    ""type"": ""Button"",
                    ""id"": ""eb46eca5-1475-4b6e-9657-1b7df3792dab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""807e6c1b-e553-4372-a461-4735dd595b34"",
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
                    ""name"": """",
                    ""id"": ""6eaf7aba-ef49-418e-b51a-b578912c7516"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""717bdf49-b13d-4e6e-93e2-7eaa193cd10d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e75e385-d6e0-49c3-bd0b-1b48639ff90b"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
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
                    ""action"": ""Moving"",
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
                    ""action"": ""Moving"",
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
                    ""action"": ""Moving"",
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
                    ""action"": ""Moving"",
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
                    ""action"": ""Moving"",
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
                    ""action"": ""Moving"",
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
                    ""action"": ""Moving"",
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
                    ""action"": ""Moving"",
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
                    ""action"": ""Moving"",
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
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0b70c3cb-ab04-4555-8e05-0bab28b9558c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Space"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
                    ""id"": ""b13a0a0b-3bb1-4caf-a41d-8882cad2401d"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keys"",
                    ""id"": ""6d2d5d29-601a-40b5-80c3-81eb833f6538"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraZoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""33acc8d8-69ac-4ad5-83bc-d65eff4d4c73"",
                    ""path"": ""<Keyboard>/minus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""704992fa-877f-4ced-9972-5c2083a5f812"",
                    ""path"": ""<Keyboard>/equals"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Character"",
            ""id"": ""7ff52042-9ea5-4514-854b-930f365b4dba"",
            ""actions"": [
                {
                    ""name"": ""Space"",
                    ""type"": ""Button"",
                    ""id"": ""cdcada2e-ba59-482a-b5ee-dad1cdd7caaf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""629fa88b-0956-474d-ba22-f2caca84e137"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RMBClick"",
                    ""type"": ""Button"",
                    ""id"": ""ba6a29f5-a989-4426-84a3-480eec322cc9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LMBClick"",
                    ""type"": ""Button"",
                    ""id"": ""54c587ce-2d31-46ec-93ab-4b05b8b14160"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1fab046c-60cf-404f-bb4d-a7a766801872"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Space"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""ce4012a8-a61e-4eac-aa21-e5998314732a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3fba76c9-2826-474c-98b1-8b44408dfe7f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2340bba9-5212-48b0-8589-437586e620a3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""de35c23c-9dd1-4a59-a4de-64d2d203d3f6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""98b6986f-ab08-4aff-b0eb-d0a9e2a566cb"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""c90ab79b-0767-4d5e-ad1b-6613ee60a572"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c7508544-ffb6-4860-81a7-02874693e338"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""af21fbfe-431b-4c89-98c3-d657324dbe06"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""490ca8bd-8edd-4ac4-9c39-986081dcbd40"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""89791d06-6d7a-4aa5-9ec0-189bd6120eaa"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fbe13033-6e37-4266-8e5c-b8383e60a0dd"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RMBClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f59af210-e73b-4c85-bb27-dd3de4f90347"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LMBClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // PlayerInput
            m_PlayerInput = asset.FindActionMap("PlayerInput", throwIfNotFound: true);
            m_PlayerInput_MousePosition = m_PlayerInput.FindAction("MousePosition", throwIfNotFound: true);
            m_PlayerInput_MouseLBClick = m_PlayerInput.FindAction("MouseLBClick", throwIfNotFound: true);
            m_PlayerInput_MouseRBClick = m_PlayerInput.FindAction("MouseRBClick", throwIfNotFound: true);
            m_PlayerInput_CameraRotation = m_PlayerInput.FindAction("CameraRotation", throwIfNotFound: true);
            m_PlayerInput_CameraZoom = m_PlayerInput.FindAction("CameraZoom", throwIfNotFound: true);
            m_PlayerInput_Moving = m_PlayerInput.FindAction("Moving", throwIfNotFound: true);
            m_PlayerInput_Space = m_PlayerInput.FindAction("Space", throwIfNotFound: true);
            m_PlayerInput_Aim = m_PlayerInput.FindAction("Aim", throwIfNotFound: true);
            // Character
            m_Character = asset.FindActionMap("Character", throwIfNotFound: true);
            m_Character_Space = m_Character.FindAction("Space", throwIfNotFound: true);
            m_Character_Move = m_Character.FindAction("Move", throwIfNotFound: true);
            m_Character_RMBClick = m_Character.FindAction("RMBClick", throwIfNotFound: true);
            m_Character_LMBClick = m_Character.FindAction("LMBClick", throwIfNotFound: true);
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
        private readonly InputAction m_PlayerInput_CameraRotation;
        private readonly InputAction m_PlayerInput_CameraZoom;
        private readonly InputAction m_PlayerInput_Moving;
        private readonly InputAction m_PlayerInput_Space;
        private readonly InputAction m_PlayerInput_Aim;
        public struct PlayerInputActions
        {
            private @UserInput m_Wrapper;
            public PlayerInputActions(@UserInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @MousePosition => m_Wrapper.m_PlayerInput_MousePosition;
            public InputAction @MouseLBClick => m_Wrapper.m_PlayerInput_MouseLBClick;
            public InputAction @MouseRBClick => m_Wrapper.m_PlayerInput_MouseRBClick;
            public InputAction @CameraRotation => m_Wrapper.m_PlayerInput_CameraRotation;
            public InputAction @CameraZoom => m_Wrapper.m_PlayerInput_CameraZoom;
            public InputAction @Moving => m_Wrapper.m_PlayerInput_Moving;
            public InputAction @Space => m_Wrapper.m_PlayerInput_Space;
            public InputAction @Aim => m_Wrapper.m_PlayerInput_Aim;
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
                    @CameraRotation.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnCameraRotation;
                    @CameraRotation.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnCameraRotation;
                    @CameraRotation.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnCameraRotation;
                    @CameraZoom.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnCameraZoom;
                    @CameraZoom.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnCameraZoom;
                    @CameraZoom.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnCameraZoom;
                    @Moving.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMoving;
                    @Moving.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMoving;
                    @Moving.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMoving;
                    @Space.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnSpace;
                    @Space.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnSpace;
                    @Space.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnSpace;
                    @Aim.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnAim;
                    @Aim.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnAim;
                    @Aim.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnAim;
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
                    @CameraRotation.started += instance.OnCameraRotation;
                    @CameraRotation.performed += instance.OnCameraRotation;
                    @CameraRotation.canceled += instance.OnCameraRotation;
                    @CameraZoom.started += instance.OnCameraZoom;
                    @CameraZoom.performed += instance.OnCameraZoom;
                    @CameraZoom.canceled += instance.OnCameraZoom;
                    @Moving.started += instance.OnMoving;
                    @Moving.performed += instance.OnMoving;
                    @Moving.canceled += instance.OnMoving;
                    @Space.started += instance.OnSpace;
                    @Space.performed += instance.OnSpace;
                    @Space.canceled += instance.OnSpace;
                    @Aim.started += instance.OnAim;
                    @Aim.performed += instance.OnAim;
                    @Aim.canceled += instance.OnAim;
                }
            }
        }
        public PlayerInputActions @PlayerInput => new PlayerInputActions(this);

        // Character
        private readonly InputActionMap m_Character;
        private ICharacterActions m_CharacterActionsCallbackInterface;
        private readonly InputAction m_Character_Space;
        private readonly InputAction m_Character_Move;
        private readonly InputAction m_Character_RMBClick;
        private readonly InputAction m_Character_LMBClick;
        public struct CharacterActions
        {
            private @UserInput m_Wrapper;
            public CharacterActions(@UserInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Space => m_Wrapper.m_Character_Space;
            public InputAction @Move => m_Wrapper.m_Character_Move;
            public InputAction @RMBClick => m_Wrapper.m_Character_RMBClick;
            public InputAction @LMBClick => m_Wrapper.m_Character_LMBClick;
            public InputActionMap Get() { return m_Wrapper.m_Character; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
            public void SetCallbacks(ICharacterActions instance)
            {
                if (m_Wrapper.m_CharacterActionsCallbackInterface != null)
                {
                    @Space.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnSpace;
                    @Space.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnSpace;
                    @Space.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnSpace;
                    @Move.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                    @RMBClick.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRMBClick;
                    @RMBClick.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRMBClick;
                    @RMBClick.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRMBClick;
                    @LMBClick.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLMBClick;
                    @LMBClick.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLMBClick;
                    @LMBClick.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLMBClick;
                }
                m_Wrapper.m_CharacterActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Space.started += instance.OnSpace;
                    @Space.performed += instance.OnSpace;
                    @Space.canceled += instance.OnSpace;
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @RMBClick.started += instance.OnRMBClick;
                    @RMBClick.performed += instance.OnRMBClick;
                    @RMBClick.canceled += instance.OnRMBClick;
                    @LMBClick.started += instance.OnLMBClick;
                    @LMBClick.performed += instance.OnLMBClick;
                    @LMBClick.canceled += instance.OnLMBClick;
                }
            }
        }
        public CharacterActions @Character => new CharacterActions(this);
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
            }
        }
        public interface IPlayerInputActions
        {
            void OnMousePosition(InputAction.CallbackContext context);
            void OnMouseLBClick(InputAction.CallbackContext context);
            void OnMouseRBClick(InputAction.CallbackContext context);
            void OnCameraRotation(InputAction.CallbackContext context);
            void OnCameraZoom(InputAction.CallbackContext context);
            void OnMoving(InputAction.CallbackContext context);
            void OnSpace(InputAction.CallbackContext context);
            void OnAim(InputAction.CallbackContext context);
        }
        public interface ICharacterActions
        {
            void OnSpace(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
            void OnRMBClick(InputAction.CallbackContext context);
            void OnLMBClick(InputAction.CallbackContext context);
        }
    }
}
