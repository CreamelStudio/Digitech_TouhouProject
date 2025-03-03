using UnityEngine;

public class PowerUpText : MonoBehaviour
{
    private float tick = 255;
    private SpriteRenderer render;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        tick -= 2;
        render.color = new Color(255, 255, 255, tick);
        if(tick <= 0)
        {
            Destroy(gameObject);
        }
    }
}
