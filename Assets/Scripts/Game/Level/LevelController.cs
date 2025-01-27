using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Transform _characterSpawnPoint;
    [SerializeField] private Transform[] _obstaclesSpawnPoints;

    private ObjectPool<ObstaclesController> _obstacles;
    private LevelConfig _levelConfig;

    public void Init(LevelConfig levelConfig, ObjectPool<ObstaclesController> obstacles)
    {
        _levelConfig = levelConfig;
        _obstacles = obstacles;
        SpawnObstacle();
    }

    public Transform GetCharacterSpawnPoint()
    {
        return _characterSpawnPoint;
    }

    protected void SpawnObstacle()
    {
        ObstaclesController newObstacle = _obstacles.GetComponent();

        int randomPoinIndex = UnityEngine.Random.Range(0, _obstaclesSpawnPoints.Length);
        Transform randmPoint =  _obstaclesSpawnPoints[randomPoinIndex];

        newObstacle.gameObject.transform.position = randmPoint.position;



        Array obstacleTypes = Enum.GetValues(typeof(ObstacleTypes));

        int randomObstacleIndex = UnityEngine.Random.Range(1, obstacleTypes.Length);

        ObstacleTypes randomObstacle = (ObstacleTypes)obstacleTypes.GetValue(randomObstacleIndex);

        ObstaclesConfig obstaclesConfig = _levelConfig.GetObstacleByType(randomObstacle);

        newObstacle.Init(obstaclesConfig);
    }
}