using UnityEngine;
using Cinemachine;
using static UnityEngine.InputSystem.InputAction;
using System.Collections;

namespace Game0
{
    public class CameraController : MonoBehaviour
    {
        #region Variables and properties
        [SerializeField] private GameObject charecter;
        private Transform characterAim;

        private CinemachineVirtualCamera cinemachineVirtualCamera;

        [Header("Pan, rotate and zoom camera")]
        [SerializeField, Range(1, 5)] private float panCameraSpeed;
        [SerializeField, Range(1, 10)] private float panCameraTime;
        [SerializeField, Range(1, 5)] public float rotationAmount;
        [SerializeField, Range(1, 10)] private float zoomCameraSpeed;

        private bool isKeysHoldToPan;
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
            characterAim = charecter.transform.Find("CharacterAim");
            SetAimRelativeCharacter();

            panCameraSpeed = 0.5f;
            panCameraTime = 3;
            rotationAmount = 3;
            zoomCameraSpeed = 10f;

            isKeysHoldToPan = isKeysHoldToZoom = false;

            cinemachineVirtualCamera.m_Lens.FieldOfView = zoomOutMax;
        }

        private void Update()
        {
            //if (cameraPanDirection != CameraPanDirection.None)
            //{
            //    panCameraCorutine = StartCoroutine(PanCameraCorutine());
            //}

            //if (cameraRotationDirection != CameraRotationDirection.None)
            //{
            //    rotationCameraCorutine = StartCoroutine(RotationCameraCorutine());
            //}
        }

        #endregion

        #region Methods

        private void SetAimRelativeCharacter()
        {
            characterAim.position = charecter.transform.position;
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

            Vector3 move = lateralMove + forwardMove;
            characterAim.position += move;


            //cinemachineVirtualCamera.transform.position += move;

            //isKeysHoldToPan = context.started || context.performed ? true : false;

            //if (context.performed)
            //{
            //    ToggleAim(false);
            //    Vector2 destination = context.ReadValue<Vector2>();

            //    if (destination.y == 1)
            //        cameraPanDirection = CameraPanDirection.Up;
            //    else if (destination.y == -1)
            //        cameraPanDirection = CameraPanDirection.Down;
            //    else if (destination.x == 1)
            //        cameraPanDirection = CameraPanDirection.Left;
            //    else if (destination.x == -1)
            //        cameraPanDirection = CameraPanDirection.Right;
            //}

            //if (context.canceled) cameraPanDirection = CameraPanDirection.None;
        }

        public void OnCameraRotationChanged(CallbackContext context)
        {
            float rotationDirection = context.ReadValue<float>();

            float scrollSpeed = -zoomCameraSpeed * rotationDirection;

            Vector3 verticalMove = new Vector3(0, scrollSpeed, 0);


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
            if (context.performed)
            {
                float fov = cinemachineVirtualCamera.m_Lens.FieldOfView;

                float zoom = context.ReadValue<float>();

                if (zoom > 0)
                    cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(fov, zoomOutMax, zoomCameraSpeed * Time.deltaTime);
                else if (zoom < 0) 
                    cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(fov, zoomInMax, zoomCameraSpeed * Time.deltaTime);
            }
        }

        private IEnumerator PanCameraCorutine()
        {
            while (isKeysHoldToPan)
            {
                //Vector3 newPosition = transform.position;

                //switch (cameraPanDirection)
                //{
                //    case CameraPanDirection.Up:
                //        newPosition += (transform.forward * panCameraSpeed);
                //        break;
                //    case CameraPanDirection.Down:
                //        newPosition += (transform.forward * -panCameraSpeed);
                //        break;
                //    case CameraPanDirection.Left:
                //        newPosition += (transform.right * panCameraSpeed);
                //        break;
                //    case CameraPanDirection.Right:
                //        newPosition += (transform.right * -panCameraSpeed);
                //        break;
                //    case CameraPanDirection.None:
                //        yield break;
                //}
                //transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * panCameraTime);
                yield return null;
            }
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

        private void ToggleAim(bool flag)
        {
            cinemachineVirtualCamera.Follow = flag ? characterAim : null;
            cinemachineVirtualCamera.LookAt = flag ? characterAim : null;
        }
        #endregion
    }
}


