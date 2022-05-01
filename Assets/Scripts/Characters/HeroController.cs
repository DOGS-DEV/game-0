using UnityEngine;
using Zenject;

namespace Game0 {
    public class HeroController : MonoBehaviour
    {
        IInputable inputable;
        private Rigidbody rigidbody;

        private float heroMovingSpeed = 1;

        [Inject]
        public void Consruct(IInputable inputable)
        {
            this.inputable = inputable;
            this.inputable.MovingEvent += OnMoving;
        }

        private void OnDestroy()
        {
            if (this.inputable != null) {
                this.inputable.MovingEvent -= OnMoving;
            }
        }

        private void OnMoving(object sender, Vector2 dest) {
            Vector3 moving = new Vector3(dest.x, 0, dest.y);
            transform.Translate(moving);
            //rigidbody.AddForce(moving * heroMovingSpeed, ForceMode.VelocityChange);
        }
    }
}


