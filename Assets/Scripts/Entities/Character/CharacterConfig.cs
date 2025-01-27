using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character", order = 1)]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;

    public float Speed => _speed;
    public float MaxSpeed => _maxSpeed;
}