using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    private ObstacleDecorator _obstacleDecorator = new ObstacleDecorator();
    private ObstaclesConfig _obstacleConfig;

    public void Init(ObstaclesConfig obstacleConfig)
    {
        _obstacleConfig = obstacleConfig;

        _obstacleDecorator.ConfigObstacle(_obstacleConfig, gameObject);
    }
}
public class ObstacleDecorator
{
    public void ConfigObstacle(ObstaclesConfig config, GameObject obstacle)
    {

        SetSprite(config.Sprite, obstacle.GetComponent<SpriteRenderer>());
        SetCollider(config.ColliderType, obstacle);
    }

    private void SetSprite(Sprite sprite, SpriteRenderer spriteRenderer)
    {
        spriteRenderer.sprite = sprite;
    }

    private void SetCollider(ColliderType2D colliderType, GameObject obstacle)
    {
        switch (colliderType)
        {
            case ColliderType2D.Box:
                obstacle.AddComponent<BoxCollider2D>();
                break;
            case ColliderType2D.Circle:
                obstacle.AddComponent<CircleCollider2D>();
                break;
            case ColliderType2D.Capsule:
                obstacle.AddComponent<CapsuleCollider2D>();
                break;
            case ColliderType2D.Polygon:
                obstacle.AddComponent<PolygonCollider2D>();
                break;
            default:
                Debug.LogError("Unknown collider type");
                break;
        }
    }
}