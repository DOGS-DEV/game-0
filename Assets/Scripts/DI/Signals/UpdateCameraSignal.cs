using Zenject;

namespace Game0 {
    /// <summary> Сингал обновления настроек камеры</summary>
    public class UpdateCameraSignal
    {
        public CameraSettings CameraSettings { get; private set; }

        public UpdateCameraSignal(CameraSettings cameraSettings)
        {
            CameraSettings = cameraSettings;
        }
    }
}

