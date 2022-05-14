using System.Collections;
using UnityEngine;

namespace Game0 {
    public class HeroController : MonoBehaviour
    {
        [SerializeField] private HeroSettings heroSettings;
        private Rigidbody heroRigidbody;
        private Animator heroAnimator;

        private void Awake()
        {
            heroRigidbody = GetComponent<Rigidbody>();
            heroAnimator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 clamping = Vector3.ClampMagnitude(new Vector3(h, 0, v), 1);

            heroAnimator.SetFloat("moveSpeed", clamping.magnitude);
            heroRigidbody.velocity = clamping * heroSettings.MoveSpeed;
        }

        public void OnMovement(object _, Vector2 vector2) {
            //movingVector = vector2;
        }
    }
}