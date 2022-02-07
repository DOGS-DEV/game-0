using UnityEngine;
using Cinemachine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.UI;
using System.Collections;

enum CameraPanDirection { None, Up, Down, Left, Right}
enum CameraRotationDirection { None, Left, Right }

namespace Game0
{
    public class CameraMovement : MonoBehaviour
    {
        #region Variables and properties
        [SerializeField] private Transform aim;
        private UserInput userInput;
        private CinemachineInputProvider cinemachineInputProvider;
        private CinemachineVirtualCamera cinemachineVirtualCamera;
        //private Transform cameraTransform;

        private CameraPanDirection cameraPanDirection;
        public float movementSpeed;
        public float movementTime;
        private bool isKeysHoldToPan;
        private Coroutine panCameraCorutine;

        private CameraRotationDirection cameraRotationDirection;
        public float rotationAmount;
        private bool isKeysHoldToZoom;
        private Coroutine rotationCameraCorutine;  

        [SerializeField] private Text cameraPanAndZoomString;
        [SerializeField, Range(1, 5)] private float zoomCameraSpeed = 5f;

        private float zoomInMax = 10f;
        private float zoomOutMax = 45f;
        #endregion

        #region MonoBehaviour methods
        private void Awake()
        {
            cinemachineInputProvider = GetComponentInChildren<CinemachineInputProvider>();
            cinemachineVirtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
            //cameraTransform = cinemachineVirtualCamera.VirtualCameraGameObject.transform;
        }

        private void Start()
        {
            movementSpeed = 1;
            movementTime = 3;
            rotationAmount = 3;

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

        public void OnMouseRightButtonClicked(CallbackContext context)
        {
            // Do something...
        }

        public void OnMouseZoomHander(CallbackContext context)
        {
            float z = cinemachineInputProvider.GetAxisValue(2);
            if (z != 0) ZoomScreen(z);
        }

        private void ZoomScreen(float increment)
        {
            float fov = cinemachineVirtualCamera.m_Lens.FieldOfView;
            float target = Mathf.Clamp(fov + increment, zoomInMax, zoomOutMax);
            cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(fov, target, zoomCameraSpeed * Time.deltaTime);
        }

        private IEnumerator PanCameraCorutine()
        {
            while (isKeysHoldToPan)
            {
                Vector3 newPosition = transform.position;

                switch (cameraPanDirection)
                {
                    case CameraPanDirection.Up:
                        newPosition += (transform.forward * movementSpeed);
                        break;
                    case CameraPanDirection.Down:
                        newPosition += (transform.forward * -movementSpeed);
                        break;
                    case CameraPanDirection.Left:
                        newPosition += (transform.right * movementSpeed);
                        break;
                    case CameraPanDirection.Right:
                        newPosition += (transform.right * -movementSpeed);
                        break;
                    case CameraPanDirection.None:
                        yield break;
                }
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
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
                transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
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


