using System.Collections;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Game0
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class BaseUserInputController : MonoBehaviour
    {
        #region Variables and properties

        protected Rigidbody rigidbodyObject;
        protected Animator animator;

        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotateSpeed;
        //[SerializeField] private float rotateAngle;
        [SerializeField] private float forceJump;

        protected Vector3 movingVector;
        protected Coroutine movingCoroutine;

        //protected float rotateDirection;
        //protected Coroutine rotationCoroutine;

        protected bool isCanJump;
        protected bool isJumping;
        protected Coroutine jumpingCoroutine;

        #endregion

        #region MonoBehaviour methods

        protected void OnEnable()
        {
            // Set Set Initial Values to Variables
            moveSpeed = 25.0f;
            rotateSpeed = 8f;
            //rotateAngle = 2.0f;
            forceJump = 45.0f;

            movingVector = Vector3.zero;

            //rotateDirection = .0f;

            isCanJump = true;
            isJumping = false;

            //Get and setting components
            rigidbodyObject = GetComponent<Rigidbody>();
            rigidbodyObject.mass = 15;
            rigidbodyObject.drag = 1.0f;

            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            // Moving
            OnMoving();
            if (movingVector != Vector3.zero)
            {
                movingCoroutine = StartCoroutine(OnMovingCoroutine());
            }

            // Rotation
            //OnRotation();
            //if (rotateDirection == -1 | rotateDirection == 1)
            //{
            //    rotationCoroutine = StartCoroutine(OnRotationCoroutine(rotateDirection));
            //}

            // Jumping
            OnJumping();
            if (isCanJump && isJumping)
            {
                jumpingCoroutine = StartCoroutine(OnJumpingCoroutine());
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            isCanJump = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            isCanJump = false;
        }

        protected void OnDisable()
        {
            StopAllCoroutines();
        }
        #endregion

        #region Methods
        protected abstract void OnMoving();
        //protected abstract void OnRotation();
        protected abstract void OnJumping();
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
        }

        //private IEnumerator OnRotationCoroutine(float direction)
        //{
        //    if (direction == -1)
        //    {
        //        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, -rotateAngle, Space.World);
        //    }
        //    else if (direction == 1)
        //    {
        //        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, rotateAngle, Space.World);
        //    }
        //    else yield return null;
        //}

        private IEnumerator OnJumpingCoroutine()
        {
            rigidbodyObject.AddForce(transform.up * forceJump, ForceMode.Impulse);
            isJumping = false;
            yield return null;
        }

        #endregion
    }



}