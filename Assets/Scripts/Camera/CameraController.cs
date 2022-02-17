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

        [Header("Pan, rotate and zoom camera")]
        [SerializeField, Range(0.05f, 0.5f)] private float panCameraSpeed;
        //[SerializeField, Range(1, 5)] public float rotationAmount;
        //[SerializeField, Range(1, 10)] private float zoomCameraSpeed;

        private bool isKeysHoldToPan;
        private Vector3 cameraPanVector;
        [SerializeField, Range(10,30)] public int maxCameraPanRadius;
        private Coroutine panCameraCorutine;

        private bool isKeysHoldToZoom;
        private Coroutine rotationCameraCorutine;

        private float zoomInMax = 10f;
        private float zoomOutMax = 45f;
        #endregion

        #region MonoBehaviour methods
        private void Awake()
        {
            cinemachineVirtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        }

        private void Start()
        {
            // Camera aim search for Pan, Rotate, and Zoom
            characterAim = character.transform.Find("CharacterAim");
            SetAimRelativeCharacter();

            cameraPanVector = Vector3.zero;
            panCameraSpeed = 0.15f;
            maxCameraPanRadius = 5;

            //rotationAmount = 3;
            //zoomCameraSpeed = 10f;

            isKeysHoldToPan = isKeysHoldToZoom = false;

            cinemachineVirtualCamera.m_Lens.FieldOfView = zoomOutMax;
        }

        private void Update()
        {

            if (cameraPanVector != Vector3.zero)
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
                        float hsp = panCameraSpeed * destination.x;

                        // Vertical speed pan camera 
                        float vsp = panCameraSpeed * destination.y;

                        Vector3 lateralMove = hsp * cinemachineVirtualCamera.transform.right;

                        Vector3 forwardMove = cinemachineVirtualCamera.transform.forward;
                        forwardMove.y = 0;
                        forwardMove.Normalize();
                        forwardMove *= vsp;

                        cameraPanVector = lateralMove + forwardMove;

                        break;
                    }
                case UnityEngine.InputSystem.InputActionPhase.Canceled:
                    {
                        isKeysHoldToPan = false;
                        cameraPanVector = Vector3.zero;
                        break;
                    }
                default:
                    break;
            }
        }

        public void OnCameraRotationChanged(CallbackContext context)
        {
            // Новое 
            //float rotationDirection = context.ReadValue<float>();

            //float scrollSpeed = -zoomCameraSpeed * rotationDirection;

            //Vector3 verticalMove = new Vector3(0, scrollSpeed, 0);

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
            //if (context.performed)
            //{
            //    float fov = cinemachineVirtualCamera.m_Lens.FieldOfView;

            //    float zoom = context.ReadValue<float>();

            //    if (zoom > 0)
            //        cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(fov, zoomOutMax, zoomCameraSpeed * Time.deltaTime);
            //    else if (zoom < 0) 
            //        cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(fov, zoomInMax, zoomCameraSpeed * Time.deltaTime);
            //}
        }

        private IEnumerator PanCameraCorutine()
        {
            Vector3 endPosition = characterAim.position + cameraPanVector;

            float distance = Vector3.Distance(character.transform.position, endPosition);

            if (distance < maxCameraPanRadius)
            {
                characterAim.position += cameraPanVector;
            }

            yield return null;
        }

        private IEnumerator RotationCameraCorutine()
        {
            while (isKeysHoldToZoom)
            {
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
            }
        }

        #endregion
    }
}


