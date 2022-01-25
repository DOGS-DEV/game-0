using System.Collections;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class UserInputScript : MonoBehaviour
{
    protected Rigidbody rigidbodyObject;

    public float moveSpeed, rotateSpeed, rotateAngle;
    Vector3 movingVector = Vector3.zero;

    Coroutine movingCoroutine;

    private void Start()
    {
        // Set initial values for variables
        moveSpeed = 30.0f;
        rotateSpeed = .3f;
        rotateAngle = 5.0f;

        //Get components
        rigidbodyObject = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (movingVector != Vector3.zero)
        {
            movingCoroutine = StartCoroutine(MovingCoroutine());
        }
    }

    #region Moving methods
    public void OnMoving(CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 direction = context.ReadValue<Vector2>();
            Debug.Log(direction);

            switch ((direction.x, direction.y))
            {
                case (-1, 0):
                    movingVector = Vector3.left;
                    break;
                case (1, 0):
                    movingVector = Vector3.right;
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
        Debug.Log("OnRotate");
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
    #endregion
}
