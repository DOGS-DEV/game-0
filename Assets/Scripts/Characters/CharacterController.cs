using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.InputSystem.InputAction;

namespace Game0
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class CharacterController : MonoBehaviour
    {
        private NavMeshAgent agent;
        private Animator animator;
        public GameObject targetDestination;
        private UserInput userInput;
        public LayerMask whatCanBeClickedOn;
        [SerializeField, Range(10.0f,100.0f)] private float allowableClickDistance = 50f;
        private bool leftButtonMouseClick = false;
        private Vector2 mouseScreenPosion = Vector2.zero;
        private RaycastHit hitInfo;

        #region MonoBehaviour methods
        private void Start()
        {
            ComponentInitialization();
        }

        private void Update()
        {
            if (leftButtonMouseClick)
            {
                Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosion);
                

                if (Physics.Raycast(ray, out hitInfo, 100, whatCanBeClickedOn))
                { 
                    targetDestination.transform.position = hitInfo.point;
                    agent.SetDestination(hitInfo.point);
                }
            }
        }

        private void OnDestroy()
        {
            userInput.PlayerInput.OnMousePosition.performed -= OnMouseScreenPosition;
            userInput.PlayerInput.OnMouseLeftButtonClick.performed -= OnMouseLeftButtonClick;
            userInput.PlayerInput.OnMouseLeftButtonClick.canceled -= OnMouseLeftButtonClick;
            userInput.PlayerInput.Disable();
            userInput.Dispose();
        }

        #endregion

        #region Methods
        private void ComponentInitialization()
        {
            //Getting and setting components
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponentInChildren<Animator>();

            // Subscribe to input events
            userInput = new UserInput();
            userInput.Enable();
            userInput.PlayerInput.OnMousePosition.performed += OnMouseScreenPosition;
            userInput.PlayerInput.OnMouseLeftButtonClick.performed += OnMouseLeftButtonClick;
            userInput.PlayerInput.OnMouseLeftButtonClick.canceled += OnMouseLeftButtonClick;
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
            leftButtonMouseClick = context.performed ? true : false;
        }
        #endregion
    }
}
