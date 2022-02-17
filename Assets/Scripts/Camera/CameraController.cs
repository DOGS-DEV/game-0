using UnityEngine;
using Cinemachine;
using static UnityEngine.InputSystem.InputAction;
using System.Collections;

namespace Game0
{
    public class CameraController : MonoBehaviour
    {
        #region Variables and properties
        [SerializeField] private GameObject character;
        private Transform characterAim;

        private CinemachineVirtualCamera cinemachineVirtualCamera;
        private CinemachineCameraOffset cinemachineCameraOffset;

        [Header("Pan, rotate and zoom camera")]
        [SerializeField, Range(0.05f, 0.5f)] private float camPanSpeed;
        private Vector3 camPanVector;
        [SerializeField, Range(10, 30)] public int camPanRadius;
        private Coroutine panCameraCorutine;
        private bool isKeysHoldToPan;

        [SerializeField, Range(10, 20)] private int camMaxZoom;
        [SerializeField, Range(1, 10)] private float camZoomSpeed;



        //[SerializeField, Range(1, 5)] public float rotationAmount;


        private bool isKeysHoldToZoom;
        private Coroutine rotationCameraCorutine;

        #endregion

        #region MonoBehaviour methods
        private void Awake()
        {
            cinemachineVirtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
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

            //rotationAmount = 3;
            camMaxZoom = 15;
            camZoomSpeed = 4f;

            isKeysHoldToPan = isKeysHoldToZoom = false;

            cinemachineCameraOffset.m_Offset = Vector3.zero;
            cinemachineVirtualCamera.m_Lens.FieldOfView = 45;
        }

        private void Update()
        {

            if (camPanVector != Vector3.zero)
            {
                panCameraCorutine = StartCoroutine(PanCameraCorutine());
            }

            //if (cameraRotationDirection != CameraRotationDirection.None)
            //{
            //    rotationCameraCorutine = StartCoroutine(RotationCameraCorutine());
            //}
        }

        #endregion

        #region Methods

        private void SetAimRelativeCharacter()
        {
            characterAim.position = character.transform.position;
            characterAim.Translate(0, 1.27f, 0);
        }

        public void OnMouseLeftButtonClicked(CallbackContext context)
        {
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
            // Старое
            //isKeysHoldToZoom = context.started || context.performed ? true : false;
            
            //if (context.performed)
            //{
            //    ToggleAim(false);

            //    float rotationDirection = context.ReadValue<float>();
            //    switch (rotationDirection)
            //    {
            //        case -1:
            //            cameraRotationDirection = CameraRotationDirection.Left;
            //            break;
            //        case 1:
            //            cameraRotationDirection = CameraRotationDirection.Right;
            //            break;
            //        default:
            //            break;
            //    }
            //}

            //if (context.canceled) cameraRotationDirection = CameraRotationDirection.None;
        }

        public void OnCameraZoomChanged(CallbackContext context)
        {
            // With offset 
            if (context.performed)
            {
                var co = cinemachineCameraOffset.m_Offset;

                float zoom = context.ReadValue<float>();

                if (zoom > 0)
                    cinemachineCameraOffset.m_Offset.z = Mathf.Lerp(co.z, camMaxZoom, camZoomSpeed * Time.deltaTime);
                else if (zoom < 0)
                    cinemachineCameraOffset.m_Offset.z = Mathf.Lerp(co.z, 0, camZoomSpeed * Time.deltaTime);
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
            //while (isKeysHoldToZoom)
            //{
                //Quaternion newRotation = transform.rotation;

                //switch (cameraRotationDirection)
                //{
                //    case CameraRotationDirection.None:
                //        yield break;
                //    case CameraRotationDirection.Left:
                //        newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
                //        break;
                //    case CameraRotationDirection.Right:
                //        newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
                //        break;
                //}
                //transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * panCameraTime);
                yield return null;
           // }
        }

        #endregion
    }
}


