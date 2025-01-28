using System.Collections;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private GameSceneCollector _sceneCollector;
    [SerializeField] private PoolObjectManager _poolObjectManager;

    private LevelTypes _currentLevel;
    private Coroutine _timer;
    private int _points; 

    private const float _second = 1f;
    

    private void Awake()
    {
        InitGame();
    }

    private void Start()
    {  
        _sceneCollector.CollectScene(_gameConfig , _currentLevel);
        StartGame();
    }
    private void OnDestroy()
    {
        UnSubscribe();
    }

    private void InitGame()
    {
        _poolObjectManager.InitPoolObjects();
        _sceneCollector.Init(_poolObjectManager);

        _currentLevel = SaveManager.PlayerPrefs.LoadEnum(GameSaveKeys.CurrentLevel, LevelTypes.Level1);

        Subscribe();
    }

    private void Subscribe()
    {
        GameEvents.OnGameFinish += StopGame;

        _poolObjectManager.Subscribe();
    }
    private void UnSubscribe()
    {
        GameEvents.OnGameFinish -= StopGame;

        _poolObjectManager.Unsubscribe();
    }
    private void StartGame()
    {
        Time.timeScale = 1f;
        GameEvents.StartGame();
        _timer = StartCoroutine(GameTimer());
    }
    private void StopGame()
    {
        Time.timeScale = 0f;
        StopCoroutine(_timer);
        SaveManager.PlayerPrefs.SaveInt(GameSaveKeys.Score, _points);
        UIManager.Instance.ShowPopup(PopupTypes.LoseGame);
    }

    private IEnumerator GameTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(_second);

            _points += _gameConfig.PointsPerSecond;
            GameEvents.UpdateTimer(_points);
        }
    }
}