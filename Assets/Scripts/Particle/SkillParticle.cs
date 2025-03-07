using Unity.VisualScripting;
using UnityEngine;

public class SkillParticle : MonoBehaviour
{
    public int tick;
    public bool isTickDown;

    public SpriteRenderer[] particleTransition;
    public Transform bigParticle;
    public SpriteRenderer bigParticleSprite;

    private void FixedUpdate()
    {
        if (tick <= 65 && !isTickDown) tick++;
        else {
            tick--;
            isTickDown = true;
        }

        for(int i = 0; i < particleTransition.Length; i++)
        {
            particleTransition[i].color = new Color(1, 1, 1, tick / 65f);
            bigParticleSprite.color = new Color(1, 1, 1, tick / 65f);
        }
        bigParticle.transform.position += Vector3.right * 5f;

        if (tick < 0) Destroy(gameObject);
    }
}
