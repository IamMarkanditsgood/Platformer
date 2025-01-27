using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private ResourcesManager _resourcesManager;
    
    private GameSceneCollector _sceneCollector;

    private LevelTypes _currentLevel;

    private void Awake()
    {
        InitGame();
    }

    private void Start()
    {
        _sceneCollector.CollectScene(_gameConfig , _currentLevel);
        GameEvents.StartGame();
    }

    private void InitGame()
    {
        _resourcesManager.Init();

        _currentLevel = SaveManager.PlayerPrefs.LoadEnum(GameSaveKeys.CurrentLevel, LevelTypes.None);
    }
}