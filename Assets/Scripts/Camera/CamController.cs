using Cinemachine;
using UnityEngine;
using Zenject;

namespace Game0 {
    public class CamController : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private CinemachineVirtualCamera cmCamera;

        [Inject]
        private void Construct (Transform camTarget, CameraSettings cameraSettings)
        {
            cmCamera.LookAt = camTarget;
            cmCamera.Follow = camTarget;
            cmCamera.m_Lens.FieldOfView = cameraSettings.fieldsOfView;
            
            var thirdPersonFollow = cmCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
            thirdPersonFollow.CameraSide = cameraSettings.cameraSide;
        }
    }
}



