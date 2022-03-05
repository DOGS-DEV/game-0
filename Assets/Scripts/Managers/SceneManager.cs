using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] GameObject character;

    void Start()
    {
        CharacterController characterController = character.GetComponent<CharacterController>();
        print(characterController);

    }
}
