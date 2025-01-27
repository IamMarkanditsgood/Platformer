using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Transform _characterSpawnPoint;
    [SerializeField] private LevelConfig _levelConfig;

    public void Init(LevelConfig levelConfig)
    {
        _levelConfig = levelConfig;
    }

    public Transform GetCharacterSpawnPoint()
    {
        return _characterSpawnPoint;
    }
}
