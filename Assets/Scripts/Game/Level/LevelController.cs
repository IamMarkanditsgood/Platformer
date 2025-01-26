using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Transform _characterSpawnPoint;

    public Transform GetSpawnPoint()
    {
        return _characterSpawnPoint;
    }
}
