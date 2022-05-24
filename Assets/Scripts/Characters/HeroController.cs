using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game0 {
    public class HeroController : MonoBehaviour
    {
        [SerializeField] private HeroSettings heroSettings;
        private Rigidbody heroRigidbody;
        private Animator heroAnimator;

        private Vector3 movingVector = Vector3.zero;
        private Coroutine movingCoroutine;

        private void Awake()
        {
            heroRigidbody = GetComponent<Rigidbody>();
            heroAnimator = GetComponentInChildren<Animator>();
        }

        private void FixedUpdate()
        {
            if(movingVector != Vector3.zero)
            {
                movingCoroutine = StartCoroutine(MovingCoroutine());
            }
        }

        public void OnMovement(Vector2 destination) {
            if (destination != Vector2.zero)
            {
                movingVector = Vector3.ClampMagnitude(new Vector3(destination.x, 0, destination.y), 1);
            }
            else {
                movingVector = Vector3.zero;
            }
        }

        public void OnJump()
        {
           heroRigidbody.AddForce(Vector3.up * heroSettings.JumpPower, ForceMode.Impulse);
        }

        public void OnClick() {
            Debug.Log("OnClick");
        }

        public void OnAim()
        {
            Debug.Log("OnAim");
        }

        private IEnumerator MovingCoroutine() {

            while (movingVector != Vector3.zero) {

                heroAnimator.SetFloat("moveSpeed", movingVector.magnitude);
                heroRigidbody.velocity = movingVector * heroSettings.MoveSpeed * Time.fixedDeltaTime;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movingVector), heroSettings.RotationSpeed * Time.fixedDeltaTime);

                yield return null;
            }

            heroAnimator.SetFloat("moveSpeed", 0);
            heroRigidbody.velocity = Vector3.Lerp(heroRigidbody.velocity, Vector3.zero, heroSettings.RotationSpeed * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, heroSettings.RotationSpeed * Time.fixedDeltaTime);

            movingCoroutine = null;
            yield break;
        }
    }
}