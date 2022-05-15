using UnityEngine;

[CreateAssetMenu(fileName = "HeroParamsConfiguration", menuName = "Configuration/HeroConfiguration", order = 0)]
public class HeroSettings : ScriptableObject
{
    [SerializeField, Tooltip("Скорость перемещения")]
    private float moveSpeed;

    [SerializeField, Tooltip("Скорость поворота")]
    private float rotationSpeed;

    /// <summary>Скорость перемещения</summary>
    public float MoveSpeed => moveSpeed;

    /// <summary>Скорость поворота</summary>
    public float RotationSpeed => rotationSpeed;
}
