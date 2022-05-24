using UnityEngine;

[CreateAssetMenu(fileName = "CameraParamsConfiguration", menuName = "Configuration/CameraConfiguration", order = 1)]
public class CameraSettings : ScriptableObject
{
    [SerializeField, Tooltip("Угол обзора"), Range(30,90)]
    private float fov = 40;

    [SerializeField, Tooltip("Дистанция от камеры до цели"), Range(2, 10)]
    private float cameraDistance = 4;


    [SerializeField, Tooltip("Плечо камеры"), Range(0, 1)]
    private float cameraSide = 1;

    [SerializeField, Tooltip("Смещение плеча камеры")]
    private Vector3 shoulderOffset = new Vector3(0.7f, 0.25f, 0f);

    /// <summary>Угол обзора камеры</summary>
    public float Fov => fov;

    /// <summary>Смещение плеча камеры</summary>
    public float CameraSide => cameraSide;

    /// <summary>Дистанция от камеры до цели"</summary>
    public float CameraDistance => cameraDistance;

    /// <summary>Смещение плеча камеры</summary>
    public Vector3 ShoulderOffset => shoulderOffset;




}
