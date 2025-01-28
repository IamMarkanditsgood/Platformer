using System;
using UnityEngine;

[Serializable]
public class ObstaclesSpawnManger
{
    [Header("x,y - lenght range, z - height")]
    [SerializeField] private Vector3 _obstaclesSpawnRange;

    private ObjectPool<ObstaclesController> _obstacles;

    public void Init(ObjectPool<ObstaclesController> obstacles)
    {
        _obstacles = obstacles;
    }

    public void SpawnObstacle(LevelConfig levelConfig, float curentDificultyCoefficient)
    {
        ObstaclesController newObstacle = _obstacles.GetComponent();

        SetObstaclePosition(newObstacle);
        InitObstacle(newObstacle, levelConfig, curentDificultyCoefficient);
    }

    private void SetObstaclePosition(ObstaclesController newObstacle)
    {
        float randomX = UnityEngine.Random.Range(_obstaclesSpawnRange.x, _obstaclesSpawnRange.y);
        float randomY = _obstaclesSpawnRange.z;

        Vector2 randomPosition = new Vector2(randomX, randomY);
        newObstacle.transform.position = randomPosition;
    }

    private void InitObstacle(ObstaclesController newObstacle, LevelConfig levelConfig, float curentDificultyCoefficient)
    {
        Array obstacleTypes = Enum.GetValues(typeof(ObstacleTypes));
        int randomObstacleIndex = UnityEngine.Random.Range(1, obstacleTypes.Length);

        ObstacleTypes randomObstacle = (ObstacleTypes)obstacleTypes.GetValue(randomObstacleIndex);
        ObstaclesConfig obstaclesConfig = levelConfig.GetObstacleByType(randomObstacle);

        newObstacle.Init(obstaclesConfig, curentDificultyCoefficient);
    }
}