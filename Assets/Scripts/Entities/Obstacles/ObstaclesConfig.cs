using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
[CreateAssetMenu(fileName = "Obstacle", menuName = "ScriptableObjects/Obstacle", order = 1)]
public class ObstaclesConfig : ScriptableObject
{
    [SerializeField] private float fallingSpeed;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private ObstacleTypes _obstacleTypes;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private ColliderType2D _colliderType;

    public float FallingSpeed => fallingSpeed;
    public LayerMask PlayerLayer => _playerLayer;  
    public ObstacleTypes ObstacleTypes => _obstacleTypes;  
    public Sprite Sprite => _sprite;
    public ColliderType2D ColliderType => _colliderType;
}
