using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystem
{
    List<Bullet> playerBullets;
    List<Bullet> enemyBullets;
    List<Unit> enemyUnits;

    public float bullet1Size = 5f;
    public float grazeSize = 1.5f;

    public void LogicUpdate() {
        playerBullets = BulletSystem._instance._bulletsByTeam[Constants.Team.Enemy];
        foreach(Bullet bullet in playerBullets)
        {
            if(PlayerUnit._instance != null) if (CircleCollider(bullet, bullet1Size, PlayerUnit._instance, PlayerUnit._instance._radius))
            {
                bullet.isDestroyed = true;
                if(!PlayerUnit._instance.isGod) PlayerUnit._instance.Damaged(1);
            }
            else if(!PlayerUnit._instance.isGod && !bullet.isGraze && CircleCollider(bullet, bullet1Size, PlayerUnit._instance, PlayerUnit._instance._radius + grazeSize))
            {
                    SoundManager.Get().PlaySound("se_graze", 0.4f);
                GrazeSystem._instance.GrazeAdd(1);
                bullet.isGraze = true;
            }
        }

        enemyUnits = UnitSystem._instnace._unitsByTeam[Constants.Team.Enemy];
        enemyBullets = BulletSystem._instance._bulletsByTeam[Constants.Team.Player];
        foreach(Bullet enemyBullet in enemyBullets)
        {
            foreach(Unit enemyUnit in enemyUnits)
            {
                if (CircleCollider(enemyUnit, enemyUnit._radius, enemyBullet, bullet1Size))
                {
                    enemyBullet.isDestroyed = true;
                    enemyUnit.Damaged(1);
                }
            }
        }
    }

    #region Circle Collider
    public bool CircleCollider(Unit unit1, float radius1, Unit unit2, float radius2)
    {
        if(Vector2.Distance(unit1.transform.position, unit2.transform.position) <= radius1 + radius2)
        {
            return true;
        }
        return false;
    }

    public bool CircleCollider(Vector2 vec1, float radius1, Vector2 vec2, float radius2)
    {
        if (Vector2.Distance(vec1, vec2) <= radius1 + radius2)
        {
            return true;
        }
        return false;
    }

    public bool CircleCollider(Bullet bullet1, float radius1, Unit unit2, float radius2)
    {
        if (Vector2.Distance(bullet1._position, unit2.transform.position) <= radius1 + radius2)
        {
            return true;
        }
        return false;
    }

    public bool CircleCollider(Unit unit1, float radius1, Bullet bullet2, float radius2)
    {
        if (Vector2.Distance(unit1.transform.position, bullet2._position) <= radius1 + radius2)
        {
            return true;
        }
        return false;
    }
    #endregion
}
