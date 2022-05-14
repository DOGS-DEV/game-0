using UnityEngine;

namespace Game0 {

    public class Scene001Manager : MonoBehaviour
    {
        [SerializeField] private HeroController hero;

        private IInputable inputable;

        private void Start()
        {
            this.inputable = new InputService();
            Subscribe();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            inputable.MovingEvent += hero.OnMovement;
        }

        private void Unsubscribe() {
            inputable.MovingEvent -= hero.OnMovement;
        }
    }

}