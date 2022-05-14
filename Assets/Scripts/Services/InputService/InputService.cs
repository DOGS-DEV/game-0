using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Game0 {

    interface IInputable
    {
        event EventHandler<Vector2> MovingEvent;
    }

    public class InputService : IInputable
    {
        private UserInput inputs;

        public event EventHandler<Vector2> MovingEvent;

        public InputService() {
            inputs = new UserInput();
            inputs.Enable();
            Subscribe();
        }

        private void Subscribe()
        {
            this.inputs.PlayerInput.Moving.started += Moving;
            this.inputs.PlayerInput.Moving.performed += Moving;
        }

        private void Unsubscribe()
        {
            this.inputs.PlayerInput.Moving.started -= Moving;
            this.inputs.PlayerInput.Moving.performed -= Moving;
        }

        private void Moving(CallbackContext context) {
            Vector2 destination = context.ReadValue<Vector2>();
            MovingEvent?.Invoke(this, destination);
        }

        ~InputService()
        {
            Unsubscribe();
            this.inputs.Disable();
            this.inputs.Dispose();
        }
    }
}