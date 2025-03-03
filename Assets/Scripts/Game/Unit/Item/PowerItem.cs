using UnityEngine;
using UnityEngine.UIElements;

public class PowerItem : MonoBehaviour
{
    private float _speed;
    public int powerUpValue;
    private int radius = 10;

    public void FixedUpdate()
    {
        transform.position = transform.position + Vector3.down * (_speed * Time.deltaTime);
        if(GameSystem._instance._collisionSystem.CircleCollider(transform.position, radius, PlayerUnit._instance.position, PlayerUnit._instance._radius))
        {
            PlayerUnit._instance.power+= powerUpValue;
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
