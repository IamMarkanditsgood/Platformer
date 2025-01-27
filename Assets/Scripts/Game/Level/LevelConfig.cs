using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 1)]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private LevelTypes _levelType;
    [SerializeField] private int _startDificultyCoefficient;
    [SerializeField] private ObstaclesConfig[] obstacles;
    

    public LevelTypes LevelType => _levelType;
    public int StartDificultyCoefficient => _startDificultyCoefficient;
    public ObstaclesConfig[] Obstacles => obstacles;
    

    public ObstaclesConfig GetObstacleByType(ObstacleTypes obstacleType)
    {
        foreach (var obstacle in obstacles)
        {
            if(obstacle.ObstacleTypes == obstacleType)
            { 
                return obstacle;
            }
        }

        Debug.LogError($"No {obstacleType} type of obstacle");
        return null;
    }
}
