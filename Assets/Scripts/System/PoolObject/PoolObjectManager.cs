using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PoolObjectManager
{
    [Header("Prefabs")]
    [SerializeField] private ObstaclesController _obstaclePrefab;
    [Header("Containers")]
    [SerializeField] private Transform _obstacleContainer;

    private ObjectPool<ObstaclesController> _obstacles = new ObjectPool<ObstaclesController>();

    public ObjectPool<ObstaclesController> Obstacles => _obstacles;

    public void InitPoolObjects()
    {
        _obstacles.InitializePool(_obstaclePrefab, _obstacleContainer);
    }

}