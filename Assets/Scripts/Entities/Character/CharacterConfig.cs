using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character", order = 1)]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private float _speed;

    public float Speed => _speed;
}