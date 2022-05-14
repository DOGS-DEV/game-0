using UnityEngine;

[CreateAssetMenu(fileName = "HeroParamsConfiguration", menuName = "Configuration/HeroConfiguration", order = 0)]
public class HeroSettings : ScriptableObject
{
    [SerializeField, Tooltip("Скорость перемещения")]
    private float moveSpeed;

    /// <summary>Скорость перемещения</summary>
    public float MoveSpeed => moveSpeed;
}
