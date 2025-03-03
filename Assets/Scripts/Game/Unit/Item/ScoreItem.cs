using UnityEngine;
using UnityEngine.UIElements;

public class ScoreItem : MonoBehaviour
{
    private float _speed;
    private int radius = 10;
    public int scoreValue;

    public void FixedUpdate()
    {
        transform.position = transform.position + Vector3.down * (_speed * Time.deltaTime);
        if(GameSystem._instance._collisionSystem.CircleCollider(transform.position, radius, PlayerUnit._instance.position, PlayerUnit._instance._radius))
        {
            ScoreSystem._instance.ScoreUp(scoreValue);
            Destroy(gameObject);
        }
        if (CheckIfOutsideOfScreen())
            Destroy(gameObject);
    }

    protected bool CheckIfOutsideOfScreen()
    {
        return transform.position.x >= 370 || transform.position.x <= -370 || transform.position.y >= 290 || transform.position.y <= -290;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }
}
