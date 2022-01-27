using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace Game0
{
    public class NewUserInputController : BaseUserInputController
    {
        private UserInput userInput;

        #region MonoBehaviour methods
        private void Awake()
        {
            userInput = new UserInput();
        }

        private new void OnEnable()
        {
            base.OnEnable();

            userInput.PlayerInput.Enable();
            userInput.PlayerInput.Movement.performed += _ => OnMoving();
            userInput.PlayerInput.Jump.performed += _ => OnJumping();
        }

        private new void OnDisable()
        {
            base.OnDisable();

            userInput.PlayerInput.Disable();
        }

        private void OnDestroy()
        {
            userInput.Dispose();
        }
        #endregion

        #region Methods
        protected override void OnMoving()
        {
            if (Keyboard.current.wKey.isPressed | Keyboard.current.upArrowKey.isPressed)
            {
                movingVector = transform.forward;
            }
            else if (Keyboard.current.sKey.isPressed | Keyboard.current.downArrowKey.isPressed)
            {
                movingVector = -transform.forward;
            }
            else if (Keyboard.current.aKey.isPressed | Keyboard.current.leftArrowKey.isPressed)
            {
                movingVector = -transform.right;
            }
            else if (Keyboard.current.dKey.isPressed | Keyboard.current.rightArrowKey.isPressed)
            {
                movingVector = transform.right;
            }
            else
            {
                movingVector = Vector3.zero;
            }
        }

        //protected override void OnRotation()
        //{
        //    rotateDirection = Keyboard.current.qKey.isPressed ? -1 : Keyboard.current.eKey.isPressed ? 1 : 0;
        //}

        protected override void OnJumping()
        {
            if(Keyboard.current.spaceKey.isPressed)
            {
                isJumping = true;
            }
        }
        #endregion
    }
}