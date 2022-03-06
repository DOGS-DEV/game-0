using System.Collections;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using static UnityEngine.InputSystem.InputActionPhase;

namespace Game0
{
    public class NativeCameraController : MonoBehaviour
    {
        [SerializeField] Transform character;
        [SerializeField] Transform focus = default;
        Vector3 focusPoint;
        private float offsetFocusY = 1.27f;
        private Coroutine setFocusRelativeCharacterCoroutine;

        [SerializeField, Range(10f, 20f), Tooltip("Дистанция от камеры от цели")]
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
        private float camRotationSpeed;
        private bool isKeyPressedToRotate;
        private float camRotateDirection;
        private Coroutine camRotationCoroutine;

        float camZoomSpeed;

        float maxHeight;
        float minHeight;

        private void Awake()
        {
            focusPoint = focus.position;

            gameObject.transform.localPosition = new Vector3(10, 12, 48);
            gameObject.transform.eulerAngles = new Vector3(35, -60, 0);

            CharacterController characterController = character.parent.GetComponent<CharacterController>();
            if (characterController != null)
            {
                characterController.PointOnMoveEvent += PointMoveEventHandler;
            }
        }

        private void Start()
        {
            focusDistance = 20.0f;
            focusRadius = 2.0f; // DeadZone
            focusCentering = 0.75f;

            camPanVector = Vector3.zero;
            camPanSpeed = 0.15f;
            camPanRadius = 15.0f;

            isKeyPressedToRotate = false;
            camRotationSpeed = 10;
            camRotateDirection = 0;
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
        }

        private void LateUpdate()
        {
            UpdateFocusPoint();
            Vector3 lookDirection = gameObject.transform.forward;
            gameObject.transform.position = focusPoint - lookDirection * focusDistance;
        }

        void UpdateFocusPoint()
        {
            Vector3 targetPoint = focus.position;
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
            switch (context.phase)
            {
                case Performed:
                    //float zooming = context.ReadValue<float>();
                    //float zoomSp = -camZoomSpeed * zooming;

                    break;
                default:
                    break;
            }

        }

        private IEnumerator CamPanCoroutine()
        {
            Vector3 endPosition = focus.position + camPanVector;

            float distance = Vector3.Distance(character.transform.position, endPosition);

            if (distance < camPanRadius)
            {
                focus.position += camPanVector;
            }
            camPanCoroutine = null;
            yield break;
        }

        private IEnumerator CamRotateCoroutine()
        {
            while (isKeyPressedToRotate)
            {
                Vector3 rotateDirection = camRotateDirection == 1 ? -Vector3.up : Vector3.up;

                transform.RotateAround(focus.position, rotateDirection, camRotationSpeed * Time.deltaTime);
                yield return null;
            }

            camRotationCoroutine = null;
            yield break;
        }



        private IEnumerator SetFocusRelativeCharacterCoroutine()
        {
            Vector3 startPosition = focus.position;
            Vector3 targetPosition = DefineFocusPosition();

            while (startPosition != targetPosition)
            {
                focus.position = Vector3.MoveTowards(startPosition, targetPosition, 0.1f);
                startPosition = focus.position;
                targetPosition = DefineFocusPosition();
                yield return null;
            }
            focus.position = targetPosition;
            setFocusRelativeCharacterCoroutine = null;
            yield break;
        }

        private Vector3 DefineFocusPosition()
        {
            return new Vector3(
                character.position.x,
                character.position.y + offsetFocusY,
                character.position.z
            );
        }
    }
}


