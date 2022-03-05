using UnityEngine;

public class NativeCameraController : MonoBehaviour
{
    [SerializeField] Transform focus = default;

    [SerializeField, Range(1f, 20f)] float focusDistance = 5f;

    private void Start()
    {
        gameObject.transform.localPosition = new Vector3(10, 12, 48);
        gameObject.transform.eulerAngles = new Vector3(35, -60, 0);
    }

    private void LateUpdate()
    {

        Vector3 focusPoint = focus.position;
        Vector3 lookDirection = gameObject.transform.forward;
        gameObject.transform.position = focusPoint - lookDirection * focusDistance;

    }

}
