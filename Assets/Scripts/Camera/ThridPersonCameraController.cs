using Cinemachine;
using UnityEngine;

namespace Game0 {

    public class ThridPersonCameraController : MonoBehaviour
    {
        [SerializeField] private CameraSettings cameraSettings;

        private CinemachineVirtualCamera cmVCam;
        private Cinemachine3rdPersonFollow threeDPerson;

        private void Awake()
        {
            cmVCam = GetComponentInChildren<CinemachineVirtualCamera>();
            threeDPerson = cmVCam.GetCinemachineComponent<Cinemachine3rdPersonFollow>();

            if (cmVCam & threeDPerson)
            {
                cmVCam.name = "cmVCam";
                CinemachineCameraSettings();
            }
            else
            {
                Debug.LogError("Не представлена CinemachineVirtualCamera для настройки!");
            }
        }

        private void Update()
        {
            CinemachineCameraSettings();
        }

        private void CinemachineCameraSettings()
        {
            cmVCam.m_Lens.FieldOfView = cameraSettings.Fov;
            threeDPerson.CameraDistance = cameraSettings.CameraDistance;
            threeDPerson.CameraSide = cameraSettings.CameraSide;
            threeDPerson.ShoulderOffset = cameraSettings.ShoulderOffset;
        }

        public void OnAim(bool flag) {
            if (flag)
            {
                print("Aim");
            }
            else {
                print("NoAim");
            }
        }
    }
}
