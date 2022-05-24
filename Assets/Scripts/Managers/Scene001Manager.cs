using UnityEngine;

namespace Game0 {

    public class Scene001Manager : MonoBehaviour
    {
        [SerializeField] private HeroController hero;
        [SerializeField] private ThridPersonCameraController cam;

        private InputService inputService;

        private void Start()
        {
            inputService = new InputService();
            Subscribe();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            EventManager.OnMove += hero.OnMovement;
            EventManager.OnSpace += hero.OnJump;
            EventManager.OnLMBClick += hero.OnClick;
            EventManager.OnRMBClick += cam.OnAim;
        }

        private void Unsubscribe() {
            EventManager.OnMove -= hero.OnMovement;
            EventManager.OnSpace -= hero.OnJump;
            EventManager.OnLMBClick -= hero.OnClick;
            EventManager.OnRMBClick -= cam.OnAim;
        }
    }
}