using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private CharacterConfig _characterConfig;
    [SerializeField] private CharacterMovementManager _characterMovementManager;
    [SerializeField] private CharacterAnimationManager _characterAnimationManager;

    private InputSystem _inputSystem = new InputSystem();

    private bool _isEnambe;

    private void FixedUpdate()
    {
        if (!_isEnambe)
            return;

        _inputSystem.UpdateInputs();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    public void Init(CharacterConfig characterConfig)
    {
        _characterConfig = characterConfig;

        _inputSystem.Init();
        _characterMovementManager.Init(_characterConfig.Speed);

        Subscribe();
    }

    private void Subscribe()
    {
        InputEvents.OnMovementDown += Run;
        GameEvents.OnGameFinish += DisableCharacterController;
        GameEvents.OnGameStart += EnableCharacterController;
    }

    private void Unsubscribe()
    {
        InputEvents.OnMovementDown -= Run;
        GameEvents.OnGameFinish -= DisableCharacterController;
        GameEvents.OnGameStart -= EnableCharacterController;
    }

    private void Run(Vector2 movementDirection)
    {
        _characterMovementManager.Move(movementDirection);
        _characterAnimationManager.Run(movementDirection.x);
    }

    private void DisableCharacterController()
    {
        SwitchCharacterControl(false);
    }

    private void EnableCharacterController()
    {
        SwitchCharacterControl(true);
    }

    private void SwitchCharacterControl(bool state)
    {
        _isEnambe = state;
        _characterMovementManager.CanMove = state;   
    }
}