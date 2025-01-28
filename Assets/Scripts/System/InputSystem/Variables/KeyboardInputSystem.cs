using UnityEngine;

public class KeyboardInputSystem : IInputable
{
    public void UpdateInput()
    {
        CheckMovementInput();
        CheckButtonsInput();
    }

    private void CheckMovementInput()
    {
        Vector2 keyboardMovementDirection;

        keyboardMovementDirection.x = Input.GetAxis("Horizontal");
        keyboardMovementDirection.y = Input.GetAxis("Vertical");

        InputEvents.MovementPressed(keyboardMovementDirection);
    }
}