using UnityEngine;
using Cinemachine;
using static UnityEngine.InputSystem.InputAction;
using System.Collections;
using UnityEngine.InputSystem;

namespace Game0
{
    public class CameraController : MonoBehaviour
    {
        #region Variables and properties
        [SerializeField] private GameObject character;
        private Transform characterAim;

        private CinemachineVirtualCamera cinemachineVirtualCamera;
        private CinemachineTransposer cinemachineTransposer;
        private CinemachineCameraOffset cinemachineCameraOffset;

        [Header("Pan, rotate and zoom camera")]
        [SerializeField, Range(20, 60)] private int camFov;
        [SerializeField, Range(-10, 20)] private int camOffsetX;
        [SerializeField, Range(-10, 20)] private int camOffsetY;

        [SerializeField, Range(0.05f, 0.5f)] private float camPanSpeed;
        private Vector3 camPanVector;
        [SerializeField, Range(10, 30)] public int camPanRadius;
        private Coroutine panCameraCorutine;
        private bool isKeysHoldToPan;

        [SerializeField, Range(10, 20)] private int camMaxZoom;
        [SerializeField, Range(1, 10)] private float camZoomSpeed;
       
        private float heroRotateDirection;
        private bool isKeysHoldToRotate;
        private Coroutine rotationCameraCorutine;

        #endregion

        #region MonoBehaviour methods
        private void Awake()
        {
            cinemachineVirtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
            cinemachineTransposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            cinemachineCameraOffset = cinemachineVirtualCamera.GetComponent<CinemachineCameraOffset>();
        }

        private void Start()
        {
            // Camera aim search for Pan, Rotate, and Zoom
            characterAim = character.transform.Find("CharacterAim");
            SetAimRelativeCharacter();

            camPanVector = Vector3.zero;
            camPanSpeed = 0.15f;
            camPanRadius = 5;
            
            camMaxZoom = 15;
            camZoomSpeed = 4f;

            heroRotateDirection = 0;

            isKeysHoldToPan = isKeysHoldToRotate = false;

            cinemachineCameraOffset.m_Offset = Vector3.zero;
            camOffsetX = camOffsetY  = 0;

            cinemachineVirtualCamera.m_Lens.FieldOfView = camFov = 45;
        }

        private void Update()
        {
            SetCameraSettings();

            if (camPanVector != Vector3.zero)
            {
                panCameraCorutine = StartCoroutine(PanCameraCorutine());
            }

            if (heroRotateDirection == 1 | heroRotateDirection == -1)
            {
                rotationCameraCorutine = StartCoroutine(RotationCameraCorutine());
            }
        }

        #endregion

        #region Methods

        private void SetCameraSettings()
        {
            if (cinemachineVirtualCamera.m_Lens.FieldOfView != camFov)
            {
                cinemachineVirtualCamera.m_Lens.FieldOfView = camFov;
            }

            if (cinemachineCameraOffset.m_Offset.x != camOffsetX)
            {
                cinemachineCameraOffset.m_Offset.x = camOffsetX;
            }

            if (cinemachineCameraOffset.m_Offset.y != camOffsetY)
            {
                cinemachineCameraOffset.m_Offset.y = camOffsetY;
            }
        }

        private void SetAimRelativeCharacter()
        {
            characterAim.position = character.transform.position;
            characterAim.Translate(0, 1.27f, 0);
        }

        public void OnMouseLeftButtonClicked(CallbackContext context)
        {
            cinemachineTransposer.m_BindingMode = CinemachineTransposer.BindingMode.WorldSpace;
            SetAimRelativeCharacter();
        }

        public void OnMouseRightButtonClicked(CallbackContext context)
        {
            // Do something...
        }

        public void OnCameraPanChanged(CallbackContext context)
        {
            switch (context.phase)
            {
                case UnityEngine.InputSystem.InputActionPhase.Started:
                    {
                        isKeysHoldToPan = true;
                        break;
                    }
                case UnityEngine.InputSystem.InputActionPhase.Performed:
                    {

                        isKeysHoldToPan = true;

                        Vector2 destination = context.ReadValue<Vector2>();

                        // Horizontal speed pan camera 
                        float hsp = camPanSpeed * destination.x;

                        // Vertical speed pan camera 
                        float vsp = camPanSpeed * destination.y;

                        Vector3 lateralMove = hsp * cinemachineVirtualCamera.transform.right;

                        Vector3 forwardMove = cinemachineVirtualCamera.transform.forward;
                        forwardMove.y = 0;
                        forwardMove.Normalize();
                        forwardMove *= vsp;

                        camPanVector = lateralMove + forwardMove;

                        break;
                    }
                case UnityEngine.InputSystem.InputActionPhase.Canceled:
                    {
                        isKeysHoldToPan = false;
                        camPanVector = Vector3.zero;
                        break;
                    }
                default:
                    break;
            }
        }

        public void OnCameraRotationChanged(CallbackContext context)
        {
            cinemachineTransposer.m_BindingMode = CinemachineTransposer.BindingMode.LockToTargetWithWorldUp;
           
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    isKeysHoldToRotate = true;
                    break;
                case InputActionPhase.Performed:
                    isKeysHoldToRotate = true;
                    heroRotateDirection = context.ReadValue<float>();
                    break;
                default:
                    isKeysHoldToRotate = false;
                    heroRotateDirection = 0;
                    break;
            }
        }

        public void OnCameraZoomChanged(CallbackContext context)
        {
            // With offset 
            if (context.performed)
            {
                var co = cinemachineCameraOffset.m_Offset;

                float zoom = context.ReadValue<float>();

                if (zoom > 0)
                    cinemachineCameraOffset.m_Offset.z = Mathf.Lerp(cinemachineCameraOffset.m_Offset.z, camMaxZoom, camZoomSpeed * Time.deltaTime);
                else if (zoom < 0)
                    cinemachineCameraOffset.m_Offset.z = Mathf.Lerp(cinemachineCameraOffset.m_Offset.z, 0, camZoomSpeed * Time.deltaTime);
            }
        }

        private IEnumerator PanCameraCorutine()
        {
            Vector3 endPosition = characterAim.position + camPanVector;

            float distance = Vector3.Distance(character.transform.position, endPosition);

            if (distance < camPanRadius)
            {
                characterAim.position += camPanVector;
            }

            yield return null;
        }

        private IEnumerator RotationCameraCorutine()
        {
            while (isKeysHoldToRotate)
            {
                var rd = heroRotateDirection;
                var rs = 0.05f;
                var ra = 1.0f;

                if (rd == 1)
                {
                    characterAim.transform.Rotate(Vector3.up * rs * Time.deltaTime, -ra, Space.World);
                    yield return null;
                }
                else if (rd == -1)
                {
                    characterAim.transform.Rotate(Vector3.up * rs * Time.deltaTime, ra, Space.World);
                    yield return null;
                }
                else
                {
                    yield break;
                }
            }
        }

        #endregion
    }
}


