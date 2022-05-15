using System.Collections;
using UnityEngine;

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

        private void Update()
        {
            //float h = Input.GetAxis("Horizontal");
            //float v = Input.GetAxis("Vertical");

            //Vector3 clamping = Vector3.ClampMagnitude(new Vector3(h, 0, v), 1);

            //heroAnimator.SetFloat("moveSpeed", clamping.magnitude);
            //heroRigidbody.velocity = clamping * heroSettings.MoveSpeed;
        }

        private void FixedUpdate()
        {
            if(movingVector != Vector3.zero)
            {
                movingCoroutine = StartCoroutine(MovingCoroutine());
            }
        }

        public void OnMovement(object _, Vector2 vector2) {
            if (vector2 != Vector2.zero)
            {
                movingVector = Vector3.ClampMagnitude(new Vector3(vector2.x, 0, vector2.y), 1);
            }
            else {
                movingVector = Vector3.zero;
            }
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