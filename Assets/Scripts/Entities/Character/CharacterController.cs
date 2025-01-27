using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private CharacterConfig _characterConfig;

    private InputSystem _inputSystem = new InputSystem();

    public void Init(CharacterConfig characterConfig)
    {
        _characterConfig = characterConfig;
        _inputSystem.Init();
    }

    private void Start()
    {
        Subscribe();
    }
    private void Update()
    {
        _inputSystem.UpdateInputs();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {

    }
    private void Unsubscribe()
    {

    }
}
