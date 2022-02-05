using UnityEngine;
using Cinemachine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.UI;

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
        [SerializeField, Range(5,10)] private float panCameraSpeed = 8f;
        [SerializeField] private Text cameraPanAndZoomString;
        [SerializeField, Range(1, 5)] private float zoomCameraSpeed = 5f;
        [SerializeField] private float zoomInMax = 13f;
        [SerializeField] private float zoomOutMax = 35f;
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
            userInput.PlayerInput.OnMouseRightButtonClick.performed += OnMouseRightButtonClicked;
            userInput.PlayerInput.OnMousePan.performed += OnMousePanHander;
            userInput.PlayerInput.OnMouseZoom.performed += OnMouseZoomHander;

            cinemachineVirtualCamera.m_Lens.FieldOfView = 35.0f;
        }

        private void Update()
        {
            //if (isPanAndZoomCamera)
            //{
            //    float x = cinemachineInputProvider.GetAxisValue(0);
            //    float y = cinemachineInputProvider.GetAxisValue(1);
            //    float z = cinemachineInputProvider.GetAxisValue(2);

            //    if (x != 0 || y != 0) PanScreen(x, y);
            //}
        }

        private void OnDestroy()
        {
            userInput.PlayerInput.OnMouseRightButtonClick.performed -= OnMouseRightButtonClicked;
            userInput.PlayerInput.OnMousePan.performed -= OnMousePanHander;
            userInput.Disable();
            userInput.Dispose();
        }
        #endregion

        #region Methods
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

        public void OnMousePanHander(CallbackContext context)
        {
            if (isPanAndZoomCamera)
            {
                cinemachineVirtualCamera.Follow = null;
                cinemachineVirtualCamera.LookAt = null;

                float x = cinemachineInputProvider.GetAxisValue(0);
                float y = cinemachineInputProvider.GetAxisValue(1);
                //float z = cinemachineInputProvider.GetAxisValue(2);

                if (x != 0 || y != 0) PanScreen(x, y);
            }
            else
            {
                cinemachineVirtualCamera.Follow = aim;
                cinemachineVirtualCamera.LookAt = aim;
            }
        }

        private Vector2 PanDirection(float x, float y)
        {
            Vector2 direction = Vector2.zero;
            float firstAdmission = .75f;
            float secondAdmission = .1f;

            if (y >= Screen.height * firstAdmission)
                direction.y += 1;
            else if (y <= Screen.height * secondAdmission)
                direction.y -= 1;

            if (x >= Screen.width * firstAdmission)
                direction.x += 1;
            else if (x <= Screen.width * secondAdmission)
                direction.x -= 1;

            return direction;
        }

        private void PanScreen(float x, float y)
        {
            Vector2 direction = PanDirection(x, y);
            cameraTransform.position = Vector3.Lerp(cameraTransform.position,
                                                    cameraTransform.position + (Vector3)direction * panCameraSpeed,
                                                    Time.deltaTime);
        }

        private void ZoomScreen(float increment)
        {
            float fov = cinemachineVirtualCamera.m_Lens.FieldOfView;
            float target = Mathf.Clamp(fov + increment, zoomInMax, zoomOutMax);
            cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(fov, target, zoomCameraSpeed * Time.deltaTime);

        }
        #endregion
    }
}


