using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.InputSystem.InputAction;

namespace Game0
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class CharacterController : MonoBehaviour
    {
        #region Variables and properties
        private NavMeshAgent agent;
        public GameObject targetDestination;
        public LayerMask whatCanBeClickedOn;
        [SerializeField, Range(10.0f,100.0f)] private float allowableClickDistance = 50f;
        private bool leftButtonMouseClick = false;
        private Vector2 mouseScreenPosion = Vector2.zero;
        private RaycastHit hitInfo;
        #endregion

        #region MonoBehaviour methods
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.updatePosition = false;
        }

        private void Update()
        {
            if (leftButtonMouseClick)
            {
                Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosion);
                if (Physics.Raycast(ray, out hitInfo, allowableClickDistance, whatCanBeClickedOn))
                { 
                    targetDestination.transform.position = hitInfo.point;
                    agent.SetDestination(hitInfo.point);
                }
            }
        }

        #endregion

        #region Methods
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