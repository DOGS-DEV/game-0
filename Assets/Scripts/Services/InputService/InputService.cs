using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Game0 {

    public class InputService
    {
        private UserInput inputs;

        public InputService() {
            inputs = new UserInput();
            inputs.Character.Enable();
            Subscribe();
        }

        private void Subscribe()
        {
            inputs.Character.Move.started += Moving;
            inputs.Character.Move.performed += Moving;
            inputs.Character.Move.canceled += Moving;

            inputs.Character.Space.performed += Spacing;

            inputs.Character.LMBClick.performed += LMBClickied;

            inputs.Character.RMBClick.performed += RMBClickied;
            inputs.Character.RMBClick.canceled += RMBClickied;
        }

        private void Unsubscribe()
        {
            inputs.Character.Move.started -= Moving;
            inputs.Character.Move.performed -= Moving;
            inputs.Character.Move.canceled -= Moving;

            inputs.Character.Space.performed -= Spacing;

            inputs.Character.LMBClick.performed -= LMBClickied;

            inputs.Character.RMBClick.performed -= RMBClickied;
            inputs.Character.RMBClick.canceled += RMBClickied;
        }

        private void Moving(CallbackContext context) {

            Vector2 destination = !context.canceled ?
                context.ReadValue<Vector2>() :
                Vector2.zero;

            EventManager.SendMoving(destination);
        }

        private void Spacing(CallbackContext context)
        {
            EventManager.SendSpace();
        }

        private void LMBClickied(CallbackContext context) {
            EventManager.SendLMBClick();
        }

        private void RMBClickied(CallbackContext context)
        {
            bool flag = false;
            if (context.performed)
                flag = !flag;
            EventManager.SendRMBClick(flag);
        }

        ~InputService()
        {
            Unsubscribe();
            this.inputs.Character.Disable();
            this.inputs.Dispose();
        }
    }
}