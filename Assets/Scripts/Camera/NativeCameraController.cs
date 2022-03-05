using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class NativeCameraController : MonoBehaviour
{
    /// <summary>Target tracking camera.</summary>
    [SerializeField] Transform focus = default;
    Vector3 focusPoint;

    /// <summary> Camera distance from target.</summary>
    [SerializeField, Range(10f, 20f), Tooltip("Дистанция камеры от цели")]
    float focusDistance;

    /// <summary>Tolerance at which camera does not track target.</summary>
    [SerializeField, Min(0f), Tooltip("Мертвая зона камеры вокруг персонажа")]
    float focusRadius;

    /// <summary>Camera centering factor.</summary>
    [SerializeField, Range(0f, 1f), Tooltip("Скорость остановки камеры после перемещения")]
    float focusCentering = 0.5f;

    private void Awake()
    {
        focusPoint = focus.position;
    }

    private void Start()
    {
        gameObject.transform.localPosition = new Vector3(10, 12, 48);
        gameObject.transform.eulerAngles = new Vector3(35, -60, 0);

        focusDistance = 20.0f;
        focusRadius = 2.0f; // DeadZone
        focusCentering = 0.75f;
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

    public void OnCameraPanHandler(CallbackContext context)
    {

    }

    public void OnCameraRotateHandler(CallbackContext context)
    {

    }

    public void OnCameraZoomHandler(CallbackContext context)
    {
        if (context.started | context.performed)
        {
            var aa = context.ReadValue<float>();
            print(aa);
        }
    }

}
