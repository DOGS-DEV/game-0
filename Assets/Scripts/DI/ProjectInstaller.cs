using Cinemachine;
using UnityEngine;
using Zenject;

namespace Game0 {

    /// <summary>Инсталлер для глобального контекста.</summary>
    public class ProjectInstaller : MonoInstaller
    {
        [Header("Hero")]
        [SerializeField] private GameObject heroPrefab;
        [SerializeField] private GameObject cameraPrefab;

        public override void InstallBindings()
        {
            // InputService
            Container.Bind<UserInput>().FromNew().AsSingle().NonLazy();
            Container.Bind<IInputable>().To<InputService>().AsSingle().NonLazy();

            // Setting and binding hero 
            Container.Bind<HeroController>().FromNewComponentOnNewPrefab(heroPrefab).AsSingle().NonLazy();

            Transform camTarget = heroPrefab.transform.Find("HeroTarget");
            if (camTarget == null)
                Debug.Log("Нет объекта цели для камеры");
            Container.Bind<Transform>().FromInstance(camTarget).AsSingle().NonLazy();
            
            Container.Bind<CamController>().FromComponentInNewPrefab(cameraPrefab).AsSingle().NonLazy();
        }
    }
}