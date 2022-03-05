using Game0.Interfaces;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Game0
{
    public class InputManager : MonoBehaviour, IInputable
    {
        public UserInput inputs { get; set; }

        private void Start()
        {
            inputs = new UserInput();
            Subscribe();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        public void OnCameraPanHandler(CallbackContext context)
        {
            // Do something...
        }

        public void OnCameraRotationHandler(CallbackContext context)
        {
            // Do something...
        }

        public void OnCameraZoomHandler(CallbackContext context)
        {
            // Do something...
        }

        public void OnMouseLeftButtonClickPanHandler(CallbackContext context)
        {
            // Do something...
        }

        public void OnMouseRightButtonClickPanHandler(CallbackContext context)
        {
            // Do something...
        }

        public void Subscribe()
        {
            inputs.Enable();

            inputs.PlayerInput.MouseLBClick.started += OnMouseLeftButtonClickPanHandler;
            inputs.PlayerInput.MouseLBClick.performed += OnMouseLeftButtonClickPanHandler;
            inputs.PlayerInput.MouseLBClick.canceled += OnMouseLeftButtonClickPanHandler;
        }

        public void Unsubscribe()
        {
            inputs.PlayerInput.MouseLBClick.started -= OnMouseLeftButtonClickPanHandler;
            inputs.PlayerInput.MouseLBClick.performed -= OnMouseLeftButtonClickPanHandler;
            inputs.PlayerInput.MouseLBClick.canceled -= OnMouseLeftButtonClickPanHandler;

            inputs.Disable();
        }
    }
}