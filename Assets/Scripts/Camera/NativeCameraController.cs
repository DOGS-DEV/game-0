using System.Collections;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using static UnityEngine.InputSystem.InputActionPhase;

namespace Game0
{
    public class NativeCameraController : MonoBehaviour
    {
        #region Variables and constants

        private const float CAM_MIN_FOV = 45f;
        private const float CAM_MAX_FOV = 60f;

        [SerializeField] Transform character;
        [SerializeField] Transform aim = default;
        Vector3 focusPoint;
        private float offsetFocusY = 1.27f;
        private Coroutine setFocusRelativeCharacterCoroutine;

        private const float FOCUS_MIN_DISTANCE = 8f;
        private const float FOCUS_MAX_DISTANCE = 20f;

        [SerializeField, Range(FOCUS_MIN_DISTANCE, FOCUS_MAX_DISTANCE), Tooltip("Дистанция от камеры от цели")]
        float focusDistance;

        [SerializeField, Min(0f), Tooltip("Мертвая зона камеры вокруг персонажа")]
        float focusRadius;

        [SerializeField, Range(0f, 1f), Tooltip("Скорость остановки камеры после перемещения")]
        float focusCentering = 0.5f;

        [SerializeField, Range(5, 50), Tooltip("Радиус панарамирования камеры относительно персонажа")]
        private float camPanRadius;
        [SerializeField, Range(0.05f, 0.5f), Tooltip("Скорость панарамирования камеры")]
        float camPanSpeed = default;
        private Vector3 camPanVector;
        private Coroutine camPanCoroutine;

        [SerializeField, Range(5, 20), Tooltip("Скорость вращения камеры")]
        private const float MIN_CAM_ROTATE_X = 25.0f;
        private const float MAX_CAM_ROTATE_X = 35.0f;

        private float camRotationSpeed;
        private bool isKeyPressedToRotate;
        private float camRotateDirection;
        private Coroutine camRotationCoroutine;

        float camCurrentZooming;
        [SerializeField, Range(0.1f, 3.0f), Tooltip("Скорость зума камеры")]
        float camZoomChangeAmount;
        private Coroutine camZoomCoroutine;

        #endregion

        #region Method

        private void Awake()
        {
            focusPoint = aim.position;

            gameObject.transform.localPosition = new Vector3(6, 10, 54);
            gameObject.transform.eulerAngles = new Vector3(MAX_CAM_ROTATE_X, 18.5f, 0);

            CharacterController characterController = character.parent.GetComponent<CharacterController>();
            if (characterController != null)
            {
                characterController.PointOnMoveEvent += PointMoveEventHandler;
            }
        }

        private void Start()
        {
            focusDistance = FOCUS_MAX_DISTANCE;
            focusRadius = 2.0f; // DeadZone
            focusCentering = 0.75f;

            camPanVector = Vector3.zero;
            camPanSpeed = 0.15f;
            camPanRadius = 15.0f;

            isKeyPressedToRotate = false;
            camRotationSpeed = 10;
            camRotateDirection = 0;

            camCurrentZooming = 0;
            camZoomChangeAmount = 3f;
        }

        private void Update()
        {
            if (camPanVector != Vector3.zero)
            {
                camPanCoroutine = StartCoroutine(CamPanCoroutine());
            }

            if (camRotateDirection != 0)
            {
                camRotationCoroutine = StartCoroutine(CamRotateCoroutine());
            }

            if (camCurrentZooming != 0)
            {
                camZoomCoroutine = StartCoroutine(CamZoomCoroutine());
            }
        }

        private void LateUpdate()
        {
            UpdateFocusPoint();
            Vector3 lookDirection = gameObject.transform.forward;
            gameObject.transform.position = focusPoint - lookDirection * focusDistance;
        }

        #endregion

        #region Event handlers

        private void PointMoveEventHandler(object sender, Vector3 _)
        {
            setFocusRelativeCharacterCoroutine = StartCoroutine(SetFocusRelativeCharacterCoroutine());
        }

        public void OnCameraPanHandler(CallbackContext context)
        {
            switch (context.phase)
            {
                case Performed:
                    Vector2 destination = context.ReadValue<Vector2>();

                    float hsp = camPanSpeed * destination.x;
                    float vsp = camPanSpeed * destination.y;

                    Vector3 lateralMove = hsp * transform.right;
                    Vector3 forwardMove = transform.forward;

                    forwardMove.y = 0;
                    forwardMove.Normalize();
                    forwardMove *= vsp;

                    camPanVector = lateralMove + forwardMove;

                    break;
                default:
                    camPanVector = Vector3.zero;
                    break;
            }
        }

        public void OnCameraRotateHandler(CallbackContext context)
        {
            isKeyPressedToRotate = context.phase == Started | context.phase == Performed ? true : false;
            camRotateDirection = context.phase == Started | context.phase == Performed ? context.ReadValue<float>() : 0;
        }

        public void OnCameraZoomHandler(CallbackContext context)
        {
            camCurrentZooming = context.phase == Performed ? context.ReadValue<float>() : 0;
        }

        #endregion

        #region Coroutines

        private IEnumerator CamPanCoroutine()
        {
            Vector3 endPosition = aim.position + camPanVector;

            float distance = Vector3.Distance(character.transform.position, endPosition);

            if (distance < camPanRadius)
            {
                aim.position += camPanVector;
            }
            camPanCoroutine = null;
            yield break;
        }

        private IEnumerator CamRotateCoroutine()
        {
            while (isKeyPressedToRotate)
            {
                Vector3 rotateDirection = camRotateDirection == 1 ? -Vector3.up : Vector3.up;

                transform.RotateAround(aim.position, rotateDirection, camRotationSpeed * Time.deltaTime);
                yield return null;
            }

            camRotationCoroutine = null;
            yield break;
        }

        private IEnumerator CamZoomCoroutine()
        {
            Vector3 targetRotation;

            float step = 0.01f;

            if (camCurrentZooming < 0)
            { 
                targetRotation = new Vector3(MAX_CAM_ROTATE_X, transform.eulerAngles.y, transform.eulerAngles.z);

                while (focusDistance < FOCUS_MAX_DISTANCE)
                {
                    focusDistance = Mathf.Lerp(focusDistance, focusDistance + camZoomChangeAmount, step);
                    transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRotation, step);
                    Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, CAM_MIN_FOV, step);

                    yield return null;
                }

            }
            else if (camCurrentZooming > 0)
            {
                targetRotation = new Vector3(MIN_CAM_ROTATE_X, transform.eulerAngles.y, transform.eulerAngles.z);

                while (focusDistance > FOCUS_MIN_DISTANCE)
                {
                    focusDistance = Mathf.Lerp(focusDistance, focusDistance - camZoomChangeAmount, step);
                    transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRotation, step);
                    Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, CAM_MAX_FOV, step);
                    yield return null;
                }
            }

            camZoomCoroutine = null;
            yield break;
        }

        private IEnumerator SetFocusRelativeCharacterCoroutine()
        {
            Vector3 startPosition = aim.position;
            Vector3 targetPosition = DefineFocusPosition();

            while (startPosition != targetPosition)
            {
                aim.position = Vector3.MoveTowards(startPosition, targetPosition, 0.1f);
                startPosition = aim.position;
                targetPosition = DefineFocusPosition();
                yield return null;
            }
            aim.position = targetPosition;
            setFocusRelativeCharacterCoroutine = null;
            yield break;
        }

        #endregion

        #region Other methods

        void UpdateFocusPoint()
        {
            Vector3 targetPoint = aim.position;
            if (focusRadius > 0f)
            {
                float distance = Vector3.Distance(targetPoint, focusPoint);
                float t = 1f;
                if (distance > 0.01f && focusCentering > 0f)
                {
                    t = Mathf.Pow(1f - focusCentering, Time.unscaledDeltaTime);
                }

                if (distance > focusRadius)
                {
                    t = Mathf.Min(t, focusRadius / distance);
                }
                focusPoint = Vector3.Lerp(targetPoint, focusPoint, t);
            }
            else
            {
                focusPoint = targetPoint;
            }
        }

        private Vector3 DefineFocusPosition()
        {
            return new Vector3(
                character.position.x,
                character.position.y + offsetFocusY,
                character.position.z
            );
        }

        #endregion
    }
}