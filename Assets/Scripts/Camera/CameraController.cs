using UnityEngine;
using Cinemachine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.UI;
using System.Collections;

enum CameraPanDirection { None, Up, Down, Left, Right}
enum CameraRotationDirection { None, Left, Right }

namespace Game0
{
    public class CameraController : MonoBehaviour
    {
        #region Variables and properties
        [SerializeField] private Transform aim;
        private UserInput userInput;
        private CinemachineVirtualCamera cinemachineVirtualCamera;

        [Header("Pan, rotate and zoom camera")]
        [SerializeField, Range(1,5)]    private float panCameraSpeed;
        [SerializeField, Range(1,10)]   private float panCameraTime;
        [SerializeField, Range(1,5)]    public float rotationAmount;
        [SerializeField, Range(1,10)]   private float zoomCameraSpeed;

        private CameraPanDirection cameraPanDirection;
        private bool isKeysHoldToPan;
        private Coroutine panCameraCorutine;

        private CameraRotationDirection cameraRotationDirection;
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
            panCameraSpeed = 1;
            panCameraTime = 3;
            rotationAmount = 3;
            zoomCameraSpeed = 5;

            isKeysHoldToPan = isKeysHoldToZoom = false;

            cameraPanDirection = CameraPanDirection.None;
            cameraRotationDirection = CameraRotationDirection.None;

            cinemachineVirtualCamera.m_Lens.FieldOfView = zoomOutMax;

            userInput = new UserInput();
            userInput.Enable();
            userInput.PlayerInput.OnMouseLeftButtonClick.performed += OnMouseLeftButtonClicked;
            userInput.PlayerInput.OnMouseRightButtonClick.performed += OnMouseRightButtonClicked;

            userInput.PlayerInput.CameraPan.started += OnCameraPanChanged;
            userInput.PlayerInput.CameraPan.performed += OnCameraPanChanged;
            userInput.PlayerInput.CameraPan.canceled += OnCameraPanChanged;

            userInput.PlayerInput.CameraRotation.started += OnCameraRotationChanged;
            userInput.PlayerInput.CameraRotation.performed += OnCameraRotationChanged;
            userInput.PlayerInput.CameraRotation.canceled += OnCameraRotationChanged;

            userInput.PlayerInput.OnMouseZoom.started += OnCameraZoomChanged;
            userInput.PlayerInput.OnMouseZoom.performed += OnCameraZoomChanged;
            userInput.PlayerInput.OnMouseZoom.canceled += OnCameraZoomChanged;
        }

        private void Update()
        {
            if (cameraPanDirection != CameraPanDirection.None)
            {
                panCameraCorutine = StartCoroutine(PanCameraCorutine());
            }

            if (cameraRotationDirection != CameraRotationDirection.None)
            {
                rotationCameraCorutine = StartCoroutine(RotationCameraCorutine());
            }
        }

        private void OnDestroy()
        {
            userInput.PlayerInput.OnMouseLeftButtonClick.performed -= OnMouseLeftButtonClicked;
            userInput.PlayerInput.OnMouseRightButtonClick.performed -= OnMouseRightButtonClicked;

            userInput.PlayerInput.CameraPan.started -= OnCameraPanChanged;
            userInput.PlayerInput.CameraPan.performed -= OnCameraPanChanged;
            userInput.PlayerInput.CameraPan.canceled -= OnCameraPanChanged;

            userInput.PlayerInput.CameraRotation.started -= OnCameraRotationChanged;
            userInput.PlayerInput.CameraRotation.performed -= OnCameraRotationChanged;
            userInput.PlayerInput.CameraRotation.canceled -= OnCameraRotationChanged;

            userInput.Disable();
            userInput.Dispose();
        }
        #endregion

        #region Methods

        private void OnMouseLeftButtonClicked(CallbackContext context)
        {
            ToggleAim(true);
        }

        public void OnMouseRightButtonClicked(CallbackContext context)
        {
            // Do something...
        }

        private void OnCameraPanChanged(CallbackContext context)
        {
            isKeysHoldToPan = context.started || context.performed ? true : false;

            if (context.performed)
            {
                ToggleAim(false);
                Vector2 destination = context.ReadValue<Vector2>();

                if (destination.y == 1)
                    cameraPanDirection = CameraPanDirection.Up;
                else if (destination.y == -1)
                    cameraPanDirection = CameraPanDirection.Down;
                else if (destination.x == 1)
                    cameraPanDirection = CameraPanDirection.Left;
                else if (destination.x == -1)
                    cameraPanDirection = CameraPanDirection.Right;
            }

            if (context.canceled) cameraPanDirection = CameraPanDirection.None;
        }

        private void OnCameraRotationChanged(CallbackContext context)
        {
            isKeysHoldToZoom = context.started || context.performed ? true : false;

            if (context.performed)
            {
                ToggleAim(false);

                float rotationDirection = context.ReadValue<float>();
                switch (rotationDirection)
                {
                    case -1:
                        cameraRotationDirection = CameraRotationDirection.Left;
                        break;
                    case 1:
                        cameraRotationDirection = CameraRotationDirection.Right;
                        break;
                    default:
                        break;
                }
            }

            if (context.canceled) cameraRotationDirection = CameraRotationDirection.None;
        }

        private void OnCameraZoomChanged(CallbackContext context)
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
                Vector3 newPosition = transform.position;

                switch (cameraPanDirection)
                {
                    case CameraPanDirection.Up:
                        newPosition += (transform.forward * panCameraSpeed);
                        break;
                    case CameraPanDirection.Down:
                        newPosition += (transform.forward * -panCameraSpeed);
                        break;
                    case CameraPanDirection.Left:
                        newPosition += (transform.right * panCameraSpeed);
                        break;
                    case CameraPanDirection.Right:
                        newPosition += (transform.right * -panCameraSpeed);
                        break;
                    case CameraPanDirection.None:
                        yield break;
                }
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * panCameraTime);
                yield return null;
            }
        }

        private IEnumerator RotationCameraCorutine()
        {
            while (isKeysHoldToZoom)
            {
                Quaternion newRotation = transform.rotation;

                switch (cameraRotationDirection)
                {
                    case CameraRotationDirection.None:
                        yield break;
                    case CameraRotationDirection.Left:
                        newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
                        break;
                    case CameraRotationDirection.Right:
                        newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
                        break;
                }
                transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * panCameraTime);
                yield return null;
            }
        }

        private void ToggleAim(bool flag)
        {
            cinemachineVirtualCamera.Follow = flag ? aim : null;
            cinemachineVirtualCamera.LookAt = flag ? aim : null;
        }
        #endregion
    }
}


