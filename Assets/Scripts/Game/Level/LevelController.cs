using System;
using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Transform _characterSpawnPoint;


    [SerializeField]  private ObstaclesSpawnManger _obstaclesSpawnManger;
    private LevelConfig _levelConfig;

    [SerializeField] private float _curentDificultyCoefficient;
    [SerializeField] private float _obstacleSpawnDelay;

    

    private Coroutine _levelSpawner;

    private void Start()
    {
        Subscribe(); StartGame();
    }
    private void OnDestroy()
    {
        UnSubscribe();
    }
    private void Subscribe()
    {
        GameEvents.OnGameStart += StartGame;
        GameEvents.OnGameFinish += StopGame;
        GameEvents.OnTimerUpdate += UpdateDificulty;
    }
    private void UnSubscribe()
    {
        GameEvents.OnGameStart -= StartGame;
        GameEvents.OnGameFinish -= StopGame;
        GameEvents.OnTimerUpdate -= UpdateDificulty;
    }
    public void Init(LevelConfig levelConfig, ObjectPool<ObstaclesController> obstacles)
    {
        _levelConfig = levelConfig;

        _obstaclesSpawnManger.Init(obstacles);

        _curentDificultyCoefficient = levelConfig.StartDificultyCoefficient;
        _obstacleSpawnDelay = levelConfig.StartObstacleSpawnDelay;
    }

    private void StartGame()
    {
        Debug.Log("Good");
        _levelSpawner = StartCoroutine(LevelSpawner());
    }
    private void StopGame()
    {
        Debug.Log("Good");
        StopCoroutine(_levelSpawner);
    }
    public Transform GetCharacterSpawnPoint()
    {
        return _characterSpawnPoint;
    }

    private IEnumerator LevelSpawner()
    {
        while (true)
        {
        
            _obstaclesSpawnManger.SpawnObstacle(_levelConfig, _curentDificultyCoefficient);
            yield return new WaitForSeconds(_obstacleSpawnDelay);
        }
    }
    private void UpdateDificulty(int time)
    {
        if(_curentDificultyCoefficient < GameConstants.maxDificulty && time % GameConstants.dificultyUpdateDelay == 0)
        {
            _curentDificultyCoefficient++;
            _obstacleSpawnDelay = _levelConfig.StartObstacleSpawnDelay / _curentDificultyCoefficient;
            GameEvents.UpdateDificultyCoeficient(_curentDificultyCoefficient);
        }
    }

    
}
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