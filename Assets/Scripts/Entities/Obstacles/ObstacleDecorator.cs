using UnityEngine;

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
        Collider2D existingCollider = obstacle.GetComponent<Collider2D>();
        if (existingCollider != null)
        {
            Object.Destroy(existingCollider);
        }

        switch (colliderType)
        {
            case ColliderType2D.Box:
                AddCollider<BoxCollider2D>(obstacle);
                break;
            case ColliderType2D.Circle:
                AddCollider<CircleCollider2D>(obstacle);
                break;
            case ColliderType2D.Capsule:
                AddCollider<CapsuleCollider2D>(obstacle);
                break;
            case ColliderType2D.Polygon:
                AddCollider<PolygonCollider2D>(obstacle);
                break;
            default:
                Debug.LogError("Unknown collider type");
                break;
        }
    }

    private void AddCollider<T>(GameObject obstacle) where T : Collider2D
    {
        T collider = obstacle.AddComponent<T>();
        collider.isTrigger = true;
    }
}