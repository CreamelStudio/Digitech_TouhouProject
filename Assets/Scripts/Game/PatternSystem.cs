using UnityEngine;
using UnityEngine.UIElements;

public class PatternSystem
{
    public int patternValue = 0;
    public int patternCount;
    public float _attackCooldownTimer;
    public float _moveCooldownTimer;
    public int isCanMove;

    public Vector2 position;

    public PatternSystem(int patternValue, Vector2 initPosition)
    {
        isCanMove = 1;
        patternCount = 0;

        this.patternValue = patternValue;
        this.position = initPosition;

        switch (patternValue)
        {
            case 0:
                Debug.Log("Pattern 0 Summon");
                break;
            case 1:
                Debug.Log("Pattern 1 Summon");
                _attackCooldownTimer = 80;
                break;
        }
    }

    public void LogicUpdate()
    {
        Vector3 dirvec;
        Bullet bullet;
        switch (patternValue)
        {
            case 0:
                position += new Vector2(0, Time.deltaTime * -150);

                _attackCooldownTimer--;
                if (_attackCooldownTimer > 0)
                    return;

                _attackCooldownTimer = 20;
                dirvec = (PlayerUnit._instance.position - position).normalized;
                bullet = BulletSystem.Get().SpawnNormalBullet("Bean_Blue1", Constants.Team.Enemy, position, dirvec, 200);
                bullet.SetZOffset(1);
                bullet.bulletPrefab.SetSpriteAlpha(0.5f);
                break;
            case 1:
                if(isCanMove == 1) position += new Vector2(0, Time.deltaTime * -120);
                if(isCanMove == 2) position += new Vector2(0, Time.deltaTime * 120);

                _attackCooldownTimer--;
                if (_attackCooldownTimer > 0)
                    return;

                _attackCooldownTimer = 180;
                patternCount++;
                for (int i = 0; i < 8; i++)
                {
                    dirvec = new Vector2(-0.125f * i, 1 - (0.125f* i));
                    bullet = BulletSystem.Get().SpawnNormalBullet("Bean_Blue1", Constants.Team.Enemy, position, dirvec, 200);
                    bullet.SetZOffset(1);
                    bullet.bulletPrefab.SetSpriteAlpha(0.5f);
                }
                for (int i = 0; i < 8; i++)
                {
                    dirvec = new Vector2(0.125f * i, 1 - (0.125f * i));
                    bullet = BulletSystem.Get().SpawnNormalBullet("Bean_Blue1", Constants.Team.Enemy, position, dirvec, 200);
                    bullet.SetZOffset(1);
                    bullet.bulletPrefab.SetSpriteAlpha(0.5f);
                }
                for (int i = 0; i < 8; i++)
                {
                    dirvec = new Vector2(0.125f * i, -1 + (0.125f * i));
                    bullet = BulletSystem.Get().SpawnNormalBullet("Bean_Blue1", Constants.Team.Enemy, position, dirvec, 200);
                    bullet.SetZOffset(1);
                    bullet.bulletPrefab.SetSpriteAlpha(0.5f);
                }
                for (int i = 0; i < 8; i++)
                {
                    dirvec = new Vector2(-0.125f * i, -1 + (0.125f * i));
                    bullet = BulletSystem.Get().SpawnNormalBullet("Bean_Blue1", Constants.Team.Enemy, position, dirvec, 200);
                    bullet.SetZOffset(1);
                    bullet.bulletPrefab.SetSpriteAlpha(0.5f);
                }
                if(patternCount == 1) isCanMove = 0;
                if(patternCount >= 3) isCanMove = 2;
                
                dirvec = new Vector2(0,1);
                bullet = BulletSystem.Get().SpawnNormalBullet("Bean_Blue1", Constants.Team.Enemy, position, dirvec, 200);
                bullet.SetZOffset(1);
                bullet.bulletPrefab.SetSpriteAlpha(0.5f);
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
