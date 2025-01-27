using System;
using UnityEngine;

[Serializable]
public class CharacterMovementManager
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _characterTransform; 

    private float _movementSpeed;
    private bool _isFacingRight = true;

    public bool CanMove { get; set; }

    public void Init(float movementSpeed)
    {
        _movementSpeed = movementSpeed;
    }

    public void Move(Vector2 direction)
    {

        if (!CanMove)
            return;

        Vector2 velocity = new Vector2(direction.x * _movementSpeed, _rb.velocity.y);
        _rb.velocity = velocity;

        if (direction.x < 0 && !_isFacingRight)
        {
            Flip();
        }
        else if (direction.x > 0 && _isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;

        Vector3 scale = _characterTransform.localScale;
        scale.x *= -1;
        _characterTransform.localScale = scale;
    }
}