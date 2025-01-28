using UnityEngine;

public class ObstacleMovementManager
{
    private float _fallingSpeed;

    

    public void CalculateFallingSpeed(float dificultyCoefficient, float startFallingSpeed)
    {
        _fallingSpeed = startFallingSpeed + dificultyCoefficient;
        if(_fallingSpeed > GameConstants.maxSpeed)
        {
            _fallingSpeed = GameConstants.maxSpeed;
        }
    }

    public void Move(Transform body)
    {
        body.Translate(Vector3.down * _fallingSpeed * Time.deltaTime);
    }
}