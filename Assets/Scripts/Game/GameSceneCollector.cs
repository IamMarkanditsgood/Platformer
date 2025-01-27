using System;
using UnityEngine;

[Serializable]
public class GameSceneCollector
{
    [SerializeField] private Transform _levelSpawnPoint;

    private Transform _characterSpawnPos;

    public void CollectScene(GameConfig gameConfig, LevelTypes currentLevel)
    {
        SetLevel(gameConfig.GetLevelByType(currentLevel), gameConfig.LevelController);
        SetCharacter(gameConfig.CharacterConfig, gameConfig.CharacterController);
    }

    private void SetLevel( LevelConfig levelConfig, LevelController levelController)
    {
        LevelController level = UnityEngine.Object.Instantiate(levelController);
        level.gameObject.transform.position = _levelSpawnPoint.position;

        _characterSpawnPos = level.GetCharacterSpawnPoint();

        level.Init(levelConfig);
    }

    private void SetCharacter(CharacterConfig characterConfig, CharacterController characterController)
    {
        CharacterController character = UnityEngine.Object.Instantiate(characterController);
        character.gameObject.transform.position = _characterSpawnPos.position;

        character.Init(characterConfig);
    }
}