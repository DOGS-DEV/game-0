using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.LowLevel;
using static UnityEngine.InputSystem.InputAction;

namespace Game0
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class CharacterController : MonoBehaviour
    {
        private Camera mainCamera;
        private NavMeshAgent chatacter;
        //private Rigidbody rigidbodyObject;
        private Animator animator;
        public GameObject targetDestination;
        private UserInput userInput;
        private Vector2 mouseScreenPosion;

        private Vector3 movingPoint;
        protected Coroutine movingCoroutine;

        #region MonoBehaviour methods
        private void Start()
        {
            ComponentInitialization();
        }

        private void Update()
        {
            if (movingPoint != Vector3.zero)
            {
                movingCoroutine = StartCoroutine(OnMovingCoroutine(chatacter, movingPoint));
            }
        }

        private void OnDestroy()
        {
            userInput.PlayerInput.OnMousePosition.performed -= OnMouseScreenPosition;
            userInput.PlayerInput.OnMouseLeftButtonClick.performed -= OnMouseLeftButtonClick;
            userInput.PlayerInput.Disable();
            userInput.Dispose();
        }

        #endregion

        #region Methods
        private void ComponentInitialization()
        {
            //Getting and setting components
            mainCamera = Camera.main;
            chatacter = GetComponent<NavMeshAgent>();
            animator = GetComponentInChildren<Animator>();

            //rigidbodyObject = GetComponent<Rigidbody>();
            //rigidbodyObject.mass = 15;
            //rigidbodyObject.drag = 1.0f;

            // Subscribe to input events
            userInput = new UserInput();
            userInput.Enable();
            userInput.PlayerInput.OnMousePosition.performed += OnMouseScreenPosition;
            userInput.PlayerInput.OnMouseLeftButtonClick.performed += OnMouseLeftButtonClick;
        }

        public void OnMouseScreenPosition(CallbackContext context)
        {
            if (context.performed)
            {
                mouseScreenPosion = context.ReadValue<Vector2>();
            }
        }

        public void OnMouseLeftButtonClick(CallbackContext context)
        {
            if (context.performed & mouseScreenPosion != Vector2.zero)
            {
                Ray ray = mainCamera.ScreenPointToRay(mouseScreenPosion);
                RaycastHit hitPoint;

                if (Physics.Raycast(ray, out hitPoint))
                {
                    targetDestination.transform.position = movingPoint = hitPoint.point;
                }
            }
        }

        private IEnumerator OnMovingCoroutine(NavMeshAgent agent, Vector3 point)
        {
            agent.SetDestination(point);
            animator.SetFloat("speed", 1.0f);



            //while (agent.pathStatus == NavMeshPathStatus.PathPartial)
            //{
                
            //    Debug.Log($"{agent.pathStatus}");
            //}
            yield return null;
        }
        #endregion
    }
}
