using UnityEngine;
using UnityEngine.UIElements;

public class PatternSystem
{
    public int patternValue;
    public float _attackCooldownTimer;

    public Vector2 position;

    public PatternSystem(int patternValue, Vector2 initPosition)
    {
        this.patternValue = patternValue;
        this.position = initPosition;

        switch (patternValue)
        {
            case 0:
                Debug.Log("Pattern 0 Summon");
                break;
        }
    }

    public void LogicUpdate()
    {
        switch (patternValue)
        {
            case 0:
                position += new Vector2(0, Time.deltaTime * -150);
                Debug.Log(position);

                _attackCooldownTimer--;
                if (_attackCooldownTimer > 0)
                    return;

                _attackCooldownTimer = 20;
                Vector3 dirvec = (PlayerUnit._instance.position - position).normalized;
                var bullet = BulletSystem.Get().SpawnNormalBullet("Bean_Blue1", Constants.Team.Enemy, position, dirvec, 200);
                bullet.SetZOffset(1);
                bullet.bulletPrefab.SetSpriteAlpha(0.5f);
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
        
    }
}
