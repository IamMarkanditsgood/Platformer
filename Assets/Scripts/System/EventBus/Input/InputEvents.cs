using System;
using UnityEngine;

public static class InputEvents
{
    public static event Action<Vector2> OnMovementDown;

    public static void MovementPressed(Vector2 movementDirection) => OnMovementDown?.Invoke(movementDirection);
}