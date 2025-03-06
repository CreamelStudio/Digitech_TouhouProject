using UnityEngine;

public class DeadParticle1 : MonoBehaviour
{
    public Transform trans;
    public SpriteRenderer sprite;
    public int tick;

    private void Start()
    {
        trans = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 0.5f);
    }
    private void FixedUpdate()
    {
        tick++;
        trans.localScale = new Vector3((tick / 6f) + 0.5f, (tick / 6f) + 0.5f, (tick / 6f) + 0.5f);
        sprite.color = new Color(1, 1, 1, 1f - tick / 15f);
    }
}
