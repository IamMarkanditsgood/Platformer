using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Transform _characterSpawnPoint;
    [SerializeField] private ObstaclesSpawnManger _obstaclesSpawnManger;
    [SerializeField] private float _curentDificultyCoefficient;
    [SerializeField] private float _obstacleSpawnDelay;

    private LevelConfig _levelConfig;

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
    public Transform GetCharacterSpawnPoint()
    {
        return _characterSpawnPoint;
    }

    private void StartGame()
    {
        _levelSpawner = StartCoroutine(LevelSpawner());
    }

    private void StopGame()
    {
        StopCoroutine(_levelSpawner);
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