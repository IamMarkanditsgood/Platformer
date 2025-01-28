using Unity.VisualScripting;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private LayerMask _borderLayer;

    private ObstacleDecorator _obstacleDecorator = new ObstacleDecorator();
    private ObstacleMovementManager _obstacleMovementManager = new ObstacleMovementManager();
    private ObstaclesConfig _obstacleConfig;

    private void Start()
    {
        Subscribe();
    }

    private void FixedUpdate()
    {
        _obstacleMovementManager.Move(gameObject.transform);
    }
    private void OnDestroy()
    {
        UnSubscribe();
    }

    private void Subscribe()
    {
        GameEvents.OnDificultyCoeficientUpdate += UpdateFallingSpeed;
    }

    private void UnSubscribe()
    {
        GameEvents.OnDificultyCoeficientUpdate -= UpdateFallingSpeed;
    }

    private void UpdateFallingSpeed(float newAmount)
    {
        _obstacleMovementManager.CalculateFallingSpeed(newAmount, _obstacleConfig.StartFallingSpeed);
    }
    public void Init(ObstaclesConfig obstacleConfig, float dificultyCoefficient)
    {
        _obstacleConfig = obstacleConfig;

        _obstacleDecorator.ConfigObstacle(_obstacleConfig, gameObject);

        _obstacleMovementManager.CalculateFallingSpeed(dificultyCoefficient, _obstacleConfig.StartFallingSpeed);
    }
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        
        if((_playerLayer.value & (1 << col.gameObject.layer)) >0)
        {
            HitPlayer();
        }
        if((_borderLayer.value & (1 << col.gameObject.layer)) > 0)
        {
            DestroyObstacle();
        }
    }

    private void HitPlayer()
    {
        GameEvents.FinishGame();
    }
    private void DestroyObstacle()
    {
        GameEvents.DestroyObstacle(this);
    }
}
