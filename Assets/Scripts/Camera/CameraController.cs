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
        //private Vector3 characterAimTargetPosition;
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
            characterController.PointOnMove += OnPointOnMoveHandler;

            cmVCam = GetComponentInChildren<CinemachineVirtualCamera>();
            cmVCamTransposer = cmVCam.GetCinemachineComponent<CinemachineTransposer>();
            cmVCamOffset = cmVCam.GetComponent<CinemachineCameraOffset>();
        }

        private void Start()
        {
            characterAim = cmVCam.Follow;
            characterAim.position = character.transform.position;
            //characterAimTargetPosition += new Vector3(0, 1.27f, 0);

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

        private bool MatchingCharacterPositionAndAim()
        {
            return characterAim.position.x == character.transform.position.x
                && characterAim.position.y == character.transform.position.y //+ 1.27f
                && characterAim.position.z == character.transform.position.z;
        }

        private void Update()
        {
            //characterAimTargetPosition = character.transform.position;
            //characterAimTargetPosition += new Vector3(0, 1.27f, 0);

            SetCameraSettings();

            if (MatchingCharacterPositionAndAim() && setAimRelativeCharacterCoroutine != null)
            {
                StopCoroutine(setAimRelativeCharacterCoroutine);
            }

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

        private void OnPointOnMoveHandler(object sender, Vector3 _)
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
                case InputActionPhase.Started:
                    break;
                case InputActionPhase.Performed:
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

            if (cameraZoomValue > 0)
            {
                // With Mathf.Lerp
                cmVCamOffset.m_Offset.z = Mathf.Lerp(cmVCamOffset.m_Offset.z, camMaxZoom, speed * Time.deltaTime);
                cmVCamTransposer.m_FollowOffset.y = Mathf.Lerp(cmVCamTransposer.m_FollowOffset.y, camFollowOffsetWithZoom, speed * Time.deltaTime);
                cmVCam.m_Lens.FieldOfView = Mathf.Lerp(cmVCam.m_Lens.FieldOfView, camFOVWithZoom, speed * Time.deltaTime);
                yield return null;

                // With Mathf.MoveTowards
                //while (cinemachineCameraOffset.m_Offset.z < camMaxZoom)
                //{
                //    cinemachineCameraOffset.m_Offset.z = Mathf.MoveTowards(cinemachineCameraOffset.m_Offset.z, camMaxZoom, camZoomSpeed * Time.deltaTime);
                //    CMTransposer.m_FollowOffset.y = Mathf.Lerp(CMTransposer.m_FollowOffset.y, camFollowOffsetWithZoom, camZoomSpeed * Time.deltaTime);
                //    cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(cinemachineVirtualCamera.m_Lens.FieldOfView, camFOVWithZoom, camZoomSpeed * Time.deltaTime);
                //    yield return null;
                //}
            }
            else if (cameraZoomValue < 0)
            {

                // With Mathf.Lerp
                cmVCamOffset.m_Offset.z = Mathf.Lerp(cmVCamOffset.m_Offset.z, 0, speed * Time.deltaTime);
                cmVCamTransposer.m_FollowOffset.y = Mathf.Lerp(cmVCamTransposer.m_FollowOffset.y, camFollowOffsetWithOutZoom, speed * Time.deltaTime);
                cmVCam.m_Lens.FieldOfView = Mathf.Lerp(cmVCam.m_Lens.FieldOfView, camFOVWithOutZoom, speed * Time.deltaTime);
                yield return null;

                // With Mathf.MoveTowards
                //while (cinemachineCameraOffset.m_Offset.z > 0)
                //{
                //    cinemachineCameraOffset.m_Offset.z = Mathf.MoveTowards(cinemachineCameraOffset.m_Offset.z, 0, camZoomSpeed * Time.deltaTime);
                //    CMTransposer.m_FollowOffset.y = Mathf.Lerp(CMTransposer.m_FollowOffset.y, camFollowOffsetWithOutZoom, camZoomSpeed * Time.deltaTime);
                //    cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(cinemachineVirtualCamera.m_Lens.FieldOfView, camFOVWithOutZoom, camZoomSpeed * Time.deltaTime);
                //    yield return null;
                //}
            }
        }

        private IEnumerator SetAimRelativeCharacterCoroutine()
        {
           // float time = 0;
            Vector3 startPosition = characterAim.position;

            while (startPosition != character.transform.position)
            {
                characterAim.position = Vector3.MoveTowards(startPosition, character.transform.position, 0.1f);
                //time += Time.deltaTime;
                startPosition = characterAim.position;
                yield return null;
            }
            characterAim.position = character.transform.position;
            setAimRelativeCharacterCoroutine = null;
            yield break;

            //characterAim.position = character.transform.position;
            //yield return null;

        }
        #endregion
    }
}