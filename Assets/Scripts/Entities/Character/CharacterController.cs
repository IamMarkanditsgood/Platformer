using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private CharacterConfig _characterConfig;
    [SerializeField] private CharacterMovementManager _characterMovementManager;

    private InputSystem _inputSystem = new InputSystem();

    private bool _isEnambe;

    public void Init(CharacterConfig characterConfig)
    {
        _characterConfig = characterConfig;

        _inputSystem.Init();
        _characterMovementManager.Init(_characterConfig.Speed);

        Subscribe();
    }

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

    private void Subscribe()
    {
        InputEvents.OnMovementPressed += _characterMovementManager.Move;
        GameEvents.OnGameFinish += DisableCharacterController;
        GameEvents.OnGameStart += EnableCharacterController;
    }
    private void Unsubscribe()
    {
        InputEvents.OnMovementPressed -= _characterMovementManager.Move;
        GameEvents.OnGameFinish -= DisableCharacterController;
        GameEvents.OnGameStart -= EnableCharacterController;
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
