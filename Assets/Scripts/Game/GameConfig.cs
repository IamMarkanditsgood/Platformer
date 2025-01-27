using UnityEngine;

[CreateAssetMenu(fileName = "Game", menuName = "ScriptableObjects/GameConfig", order = 1)]
public class GameConfig : ScriptableObject
{
    [SerializeField] private LevelConfig[] _levelsConfig;
    [SerializeField] private CharacterConfig _characterConfig;
    [SerializeField] private LevelController _levelController;
    [SerializeField] private CharacterController _characterController;  

    public LevelConfig[] LevelsConfig => _levelsConfig;
    public CharacterConfig CharacterConfig => _characterConfig;
    public LevelController LevelController => _levelController;
    public CharacterController CharacterController => _characterController;

    public LevelConfig GetLevelByType(LevelTypes levelType)
    {
        foreach (var level in _levelsConfig)
        {
            if (level.LevelType == levelType)
            {
                return level;
            }
        }

        Debug.LogError($"No {levelType} type of level");
        return null;
    }
}
