using UnityEngine;
using Cinemachine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.UI;
using System.Collections;

namespace Game0
{
    public class CameraMovement : MonoBehaviour
    {
        #region Variables and properties
        [SerializeField] private Transform aim;
        private UserInput userInput;
        private CinemachineInputProvider cinemachineInputProvider;
        private CinemachineVirtualCamera cinemachineVirtualCamera;
        private Transform cameraTransform;
    
        private bool isPanAndZoomCamera;
        private float panCameraSpeed = 20f;
        private Vector3 panCameraDestination = Vector3.zero;
        private Coroutine moveCameraCorutine;

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
            cameraTransform = cinemachineVirtualCamera.VirtualCameraGameObject.transform;
        }

        private void Start()
        {
            isPanAndZoomCamera = false;

            userInput = new UserInput();
            userInput.Enable();


            userInput.PlayerInput.OnMouseLeftButtonClick.performed += OnLeftButtonMouseClickChanged;
            userInput.PlayerInput.CameraPan.performed += OnCameraPanChanged;

            userInput.PlayerInput.OnMouseRightButtonClick.performed += OnMouseRightButtonClicked;
            userInput.PlayerInput.OnMouseZoom.performed += OnMouseZoomHander;

            cinemachineVirtualCamera.m_Lens.FieldOfView = zoomOutMax;
        }

        private void Update()
        {

        }

        private void OnDestroy()
        {
            userInput.PlayerInput.OnMouseRightButtonClick.performed -= OnMouseRightButtonClicked;
            userInput.Disable();
            userInput.Dispose();
        }
        #endregion

        #region Methods

        private void OnLeftButtonMouseClickChanged(CallbackContext context)
        {
            ToggleAim(true);
        }

        private void OnCameraPanChanged(CallbackContext context)
        {
            ToggleAim(false);
            Vector2 destination = context.ReadValue<Vector2>();
            Vector3 direction = Vector3.zero;

            if (destination.x == -1)
            {
                direction = -Vector3.right;
            }
            else if (destination.x == 1)
            {
                direction = Vector3.right;
            }
            else if (destination.y == 1)
            {
                direction = Vector3.forward;
            }
            else if (destination.y == -1)
            {
                direction = -Vector3.forward;
            }

            //cameraTransform.position = Vector3.Lerp(cameraTransform.position, cameraTransform.position + panCameraDestination * panCameraSpeed, Time.deltaTime);
            moveCameraCorutine = StartCoroutine(MoveCameraCorutine(direction));
        }

        private void ToggleAim(bool flag)
        {
            cinemachineVirtualCamera.Follow = flag ? aim : null;
            cinemachineVirtualCamera.LookAt = flag ? aim : null;
        }

        public void OnMouseRightButtonClicked(CallbackContext context)
        {
            isPanAndZoomCamera = !isPanAndZoomCamera;

            switch (isPanAndZoomCamera)
            {
                case true:
                    cameraPanAndZoomString.text = $"Camera pan and zoom: true";
                    cameraPanAndZoomString.color = Color.green;
                    break;
                case false:
                    cameraPanAndZoomString.text = $"Camera pan and zoom: false";
                    cameraPanAndZoomString.color = Color.red;
                    break;
            }
        }

        public void OnMouseZoomHander(CallbackContext context)
        {
            if (isPanAndZoomCamera)
            {
                //cinemachineVirtualCamera.Follow = null;
                //cinemachineVirtualCamera.LookAt = null;

                float z = cinemachineInputProvider.GetAxisValue(2);
                if (z != 0) ZoomScreen(z);
            }
            else
            {
                //cinemachineVirtualCamera.Follow = aim;
                //cinemachineVirtualCamera.LookAt = aim;
            }
        }

        private void ZoomScreen(float increment)
        {
            float fov = cinemachineVirtualCamera.m_Lens.FieldOfView;
            float target = Mathf.Clamp(fov + increment, zoomInMax, zoomOutMax);
            cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(fov, target, zoomCameraSpeed * Time.deltaTime);
        }


        private IEnumerator MoveCameraCorutine(Vector3 direction)
        {
            float cointer = panCameraSpeed;
            while (cointer != 0)
            {
                cameraTransform.position += direction * panCameraSpeed * Time.deltaTime;
                cointer--;
                yield return null;
            }
        }

        #endregion
    }
}


