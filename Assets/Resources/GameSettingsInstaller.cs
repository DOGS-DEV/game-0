using UnityEngine;
using Zenject;

namespace Game0
{
    public struct CameraSettings {
        public float cameraSide;
        public float fieldsOfView;

    }

    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        [SerializeField, Tooltip("Плечо камеры"), Range(0, 1)]
        private float cameraSide;

        [SerializeField, Tooltip("Поле зрения камеры"), Range(40, 80)]
        private float fieldsOfView;

        public override void InstallBindings()
        {
            CameraSettings cameraSettings = Container.Instantiate<CameraSettings>();
            cameraSettings.cameraSide = cameraSide;
            cameraSettings.fieldsOfView = fieldsOfView;

            Container.BindInstance(cameraSettings);
        }
    }
}