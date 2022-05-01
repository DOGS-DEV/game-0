using Cinemachine;
using UnityEngine;
using Zenject;

namespace Game0 {

    /// <summary>Инсталлер для глобального контекста.</summary>
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private GameObject heroPrefab;
        [SerializeField] private GameObject cameraPrefab;

        public override void InstallBindings()
        {
            Container.Bind<UserInput>().FromNew().AsSingle().NonLazy();

            Container.Bind<IInputable>().To<InputService>().AsSingle().NonLazy();

            // Setting and binding hero 
            Container.Bind<HeroController>().FromNewComponentOnNewPrefab(heroPrefab).AsSingle().NonLazy();

            // Setting and binding camera
            Camera camera = cameraPrefab.GetComponent<Camera>();
            CinemachineVirtualCamera cmVirtualCamera = cameraPrefab.GetComponent<CinemachineVirtualCamera>();
            Transform target = heroPrefab.transform.Find("HeroTarget");
            cmVirtualCamera.Follow = target;
            Container.Bind<Camera>().FromNewComponentOnNewPrefab(camera).AsSingle().NonLazy();
        }
    }
}