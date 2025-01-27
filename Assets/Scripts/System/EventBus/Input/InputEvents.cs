using System;
using UnityEngine;

public static class InputEvents
{
    public static event Action<Vector2> OnMovementPressed;

    public static void MovementPressed(Vector2 movementDirection)
    {
        OnMovementPressed?.Invoke(movementDirection);
    }
}