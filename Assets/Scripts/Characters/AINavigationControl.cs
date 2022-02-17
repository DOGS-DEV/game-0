using UnityEngine;
using UnityEngine.AI;

namespace Game0
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
    public class AINavigationControl : MonoBehaviour
    {
        #region Variables and properties
        Animator animator;
        NavMeshAgent agent;
        Vector3 worldDeltaPosition;
        Vector2 groundDeltaPosition;
        Vector2 velocity = Vector2.zero;
        #endregion

        #region MonoBehaviour methods
        private void Start()
        {
            animator = GetComponentInChildren<Animator>();
            agent = GetComponent<NavMeshAgent>();
            agent.updatePosition = false;
        }

        private void Update()
        {
            worldDeltaPosition = agent.nextPosition - transform.position;
            groundDeltaPosition.x = Vector3.Dot(transform.right, worldDeltaPosition);
            groundDeltaPosition.y = Vector3.Dot(transform.forward, worldDeltaPosition);
            velocity = Time.deltaTime > 1e-5f ? groundDeltaPosition / Time.deltaTime : Vector2.zero;

            bool shouldMove = velocity.magnitude > 0.025f && agent.remainingDistance > agent.radius;

            animator.SetBool("isMoving", shouldMove);
            animator.SetFloat("velx", velocity.x);
            animator.SetFloat("vely", velocity.y);
        }

        private void OnAnimatorMove()
        {
            transform.position = agent.nextPosition;
        }
        #endregion
    }
}

