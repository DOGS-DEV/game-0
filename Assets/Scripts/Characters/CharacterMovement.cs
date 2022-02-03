using System.Collections;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Game0
{
    public class CharacterMovement : MonoBehaviour
    {
        #region Variables and properties
        private Rigidbody rigidbodyObject;
        private Animator animator;
        private UserInput userInput;

        // Movement
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotateSpeed;
        protected Vector3 movingVector = Vector3.zero;
        protected Coroutine movingCoroutine;
        #endregion

        #region MonoBehaviour methods
        private void Awake()
        {
            userInput = new UserInput();
        }

        private void Start()
        {
            // Set Set Initial Values to Variables
            moveSpeed = 10.0f;
            rotateSpeed = 3.0f;

            //Getting and setting components
            rigidbodyObject = GetComponent<Rigidbody>();
            rigidbodyObject.mass = 15;
            rigidbodyObject.drag = 1.0f;

            animator = GetComponent<Animator>();

            userInput.PlayerInput.Movement.performed += OnMoving;
            userInput.PlayerInput.Movement.canceled += OnMoving;
        }

        private void FixedUpdate()
        {
            movingCoroutine = StartCoroutine(OnMovingCoroutine());
        }

        private void OnEnable()
        {
            userInput.Enable();
        }

        private void OnDisable()
        {
            userInput.Disable();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
            userInput.PlayerInput.Movement.performed -= OnMoving;
            userInput.Dispose();
        }
        #endregion

        #region
        public void OnMoving(CallbackContext callback)
        {
            Vector2 direction = callback.ReadValue<Vector2>();
            movingVector = (callback.canceled || direction == Vector2.zero)
                ? Vector3.zero
                : movingVector = new Vector3(direction.x, 0, direction.y);
        }
        #endregion

        #region Corutines
        private IEnumerator OnMovingCoroutine()
        {
            if (movingVector != Vector3.zero)
            {
                Vector3 clampingVector = Vector3.ClampMagnitude(movingVector, 1);

                // Rotate For direction
                if (movingVector.magnitude > Mathf.Abs(0.1f))
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movingVector), Time.fixedDeltaTime * rotateSpeed);
                }

                // Play animation
                animator.SetFloat("speed", clampingVector.magnitude);

                // Add velocity with vector limit to 1
                rigidbodyObject.velocity += clampingVector * moveSpeed * Time.fixedDeltaTime;

                yield return new WaitForFixedUpdate();
            }
            else
            {
                // Stop animation
                animator.SetFloat("speed", 0);
                yield break;
            }
        }
        #endregion
    }
}