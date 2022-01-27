using System.Collections;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class UserInputScript : MonoBehaviour
{
    #region Variables and properties
    private Rigidbody rigidbodyObject;

    public float moveSpeed, rotateSpeed, rotateAngle, forceJump;
    private Vector3 movingVector = Vector3.zero;
    private float rotateDirection = .0f;

    private Coroutine movingCoroutine;
    private Coroutine rotationCoroutine;
    #endregion

    #region Native methods
    private void Start()
    {
        // Set initial values for variables
        moveSpeed = 25.0f;
        rotateSpeed = .1f;
        rotateAngle = 2.0f;
        forceJump = 45.0f;

        //Get components
        rigidbodyObject = GetComponent<Rigidbody>();
        rigidbodyObject.mass = 15;
        rigidbodyObject.drag = 1f;
    }

    private void Update()
    {
        // Moving
        if (movingVector != Vector3.zero)
        {
            movingCoroutine = StartCoroutine(MovingCoroutine());
        }

        // Rotation
        if (rotateDirection == -1 | rotateDirection == 1)
        {
            rotationCoroutine = StartCoroutine(RotationCoroutine(rotateDirection));
        }
    }
    #endregion

    #region Moving methods
    public void OnMoving(CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 direction = context.ReadValue<Vector2>();

            switch ((direction.x, direction.y))
            {
                case (-1, 0):
                    movingVector = -transform.right;
                    break;
                case (1, 0):
                    movingVector = transform.right;
                    break;
                case (0, -1):
                    movingVector = -transform.forward;
                    break;
                case (0, 1):
                    movingVector = transform.forward;
                    break;

                default:
                    movingVector = Vector3.zero;
                    break;
            }
        }
        else
        {
            movingVector = Vector2.zero;
        }
    }

    public void OnRotate(CallbackContext context)
    {
        rotateDirection = context.performed ? context.ReadValue<float>() : .0f;
    }

    public void OnJump(CallbackContext context)
    {
        rigidbodyObject.AddForce(transform.up * forceJump, ForceMode.Impulse);
    }
    #endregion

    #region Coroutines
    private IEnumerator MovingCoroutine()
    {
        if (movingVector != Vector3.zero)
        {
            rigidbodyObject.velocity += movingVector * moveSpeed * Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        else
        {
            yield return null;
        }
    }

    private IEnumerator RotationCoroutine(float direction)
    {
        if (direction == -1)
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, -rotateAngle, Space.World);
        }
        else if (direction == 1)
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, rotateAngle, Space.World);
        }
        else yield return null;
    }
    #endregion
}
