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
        private CharacterController characterController;

        private Transform characterAim;
        private float offsetAimY = 1.27f;
        private Coroutine setAimRelativeCharacterCoroutine;

        private CinemachineVirtualCamera cmVCam;
        private CinemachineTransposer cmVCamTransposer;
        private CinemachineCameraOffset cmVCamOffset;

        [Header("Pan, rotate and zoom camera")]
        [SerializeField, Range(20, 60)] private int camFOVWithOutZoom;
        [SerializeField, Range(40, 100)] private float camFOVWithZoom;

        [SerializeField, Range(-10, 20)] private int camOffsetX;
        [SerializeField, Range(-10, 20)] private int camOffsetY;
        
        [Space]
        [SerializeField, Range(0.05f, 0.5f)] private float camPanSpeed;
        private Vector3 camPanVector;
        [SerializeField, Range(5, 30),Tooltip("Максимальный радиус перемещения камеры от персонажа")]
        public int camPanRadius;
        private Coroutine panCameraCorutine;
        private bool isKeysHoldToPan;

        [Space]
        [SerializeField, Range(10, 20)] private int camMaxZoom;
        [SerializeField, Range(1, 5)] private float camZoomSpeed;
        private float cameraZoomValue;
        private float camFollowOffsetWithOutZoom = 10;
        private float camFollowOffsetWithZoom = 6;
        private Coroutine zoomCameraCorutine;

        private float heroRotateDirection;
        private bool isKeysHoldToRotate;
        private Coroutine rotationCameraCorutine;

        #endregion

        #region MonoBehaviour methods
        private void Awake()
        {
            var characterController = character.GetComponent<CharacterController>();
            characterController.PointOnMoveEvent += PointMoveEventHandler;

            cmVCam = GetComponentInChildren<CinemachineVirtualCamera>();
            cmVCamTransposer = cmVCam.GetCinemachineComponent<CinemachineTransposer>();
            cmVCamOffset = cmVCam.GetComponent<CinemachineCameraOffset>();
        }

        private void Start()
        {
            characterAim = cmVCam.Follow;
            characterAim.position = DefineCharacterAimPosition();

            camFOVWithOutZoom = 45;
            camFOVWithZoom = 60;

            cmVCamTransposer.m_FollowOffset.y = camFollowOffsetWithOutZoom = 10;
            camFollowOffsetWithZoom = 6;

            camPanVector = Vector3.zero;
            camPanSpeed = 0.15f;
            camPanRadius = 15;

            cameraZoomValue = 0;
            camMaxZoom = 11;
            camZoomSpeed = 0.5f;

            heroRotateDirection = 0;

            isKeysHoldToPan = isKeysHoldToRotate = false;

            cmVCamOffset.m_Offset = Vector3.zero;
            camOffsetX = camOffsetY  = 0;

            cmVCam.m_Lens.FieldOfView = camFOVWithOutZoom = 45;
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

            if (cameraZoomValue != 0)
            {
                zoomCameraCorutine = StartCoroutine(ZoomCameraCorutine());
            }
        }

        #endregion

        #region Methods

        private void SetCameraSettings()
        {
            if (cmVCamOffset.m_Offset.x != camOffsetX)
            {
                cmVCamOffset.m_Offset.x = camOffsetX;
            }

            if (cmVCamOffset.m_Offset.y != camOffsetY)
            {
                cmVCamOffset.m_Offset.y = camOffsetY;
            }
        }

        private void PointMoveEventHandler(object sender, Vector3 _)
        {
            if (cmVCamTransposer.m_BindingMode != CinemachineTransposer.BindingMode.LockToTargetOnAssign)
            {
                cmVCamTransposer.m_BindingMode = CinemachineTransposer.BindingMode.LockToTargetOnAssign;
            }

            setAimRelativeCharacterCoroutine = StartCoroutine(SetAimRelativeCharacterCoroutine());
        }

        public void OnMouseRightButtonClicked(CallbackContext _)
        {
            // Do something...
        }

        public void OnCameraPanChanged(CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    {
                        isKeysHoldToPan = true;
                        break;
                    }
                case InputActionPhase.Performed:
                    {
                        isKeysHoldToPan = true;

                        Vector2 destination = context.ReadValue<Vector2>();

                        // Horizontal speed pan camera 
                        float hsp = camPanSpeed * destination.x;

                        // Vertical speed pan camera 
                        float vsp = camPanSpeed * destination.y;

                        Vector3 lateralMove = hsp * cmVCam.transform.right;

                        Vector3 forwardMove = cmVCam.transform.forward;
                        forwardMove.y = 0;
                        forwardMove.Normalize();
                        forwardMove *= vsp;

                        camPanVector = lateralMove + forwardMove;

                        break;
                    }
                case InputActionPhase.Canceled:
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
            cmVCamTransposer.m_BindingMode = CinemachineTransposer.BindingMode.LockToTargetWithWorldUp;
           
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
            switch (context.phase)
            {
                case InputActionPhase.Started | InputActionPhase.Performed:
                    cameraZoomValue = context.ReadValue<float>();
                    
                    break;
                case InputActionPhase.Canceled:
                    cameraZoomValue = 0;
                    break;
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

        private IEnumerator ZoomCameraCorutine()
        {
            float speed = 2.5f;

            float cmVCamOffsetYTarget = cameraZoomValue > 0 ? camMaxZoom : 0;
            float cmVCamTransOffsetYTarget = cameraZoomValue > 0 ? camFollowOffsetWithZoom : camFollowOffsetWithOutZoom;
            float cmVCamFOVTarget = cameraZoomValue > 0 ? camFOVWithZoom : camFOVWithOutZoom;

            cmVCamOffset.m_Offset.z = Mathf.Lerp(cmVCamOffset.m_Offset.z, cmVCamOffsetYTarget, Time.deltaTime * speed);
            cmVCamTransposer.m_FollowOffset.y = Mathf.Lerp(cmVCamTransposer.m_FollowOffset.y, cmVCamTransOffsetYTarget, Time.deltaTime * speed);
            cmVCam.m_Lens.FieldOfView = Mathf.Lerp(cmVCam.m_Lens.FieldOfView, cmVCamFOVTarget, Time.deltaTime * speed);

            cameraZoomValue = 0;
            zoomCameraCorutine = null;
            yield break;
        }

        private IEnumerator SetAimRelativeCharacterCoroutine()
        {
            print("Yep!");

            Vector3 startPosition = characterAim.position;
            Vector3 targetPosition = DefineCharacterAimPosition();

            while (startPosition != DefineCharacterAimPosition())
            {
                characterAim.position = Vector3.MoveTowards(startPosition, targetPosition, 0.25f);
                startPosition = characterAim.position;
                targetPosition = DefineCharacterAimPosition();
                yield return null;
            }
            characterAim.position = targetPosition;
            setAimRelativeCharacterCoroutine = null;
            yield break;
        }

        private Vector3 DefineCharacterAimPosition()
        {
            return new Vector3(
                character.transform.position.x,
                character.transform.position.y + offsetAimY,
                character.transform.position.z
            );
        }

        #endregion
    }
}