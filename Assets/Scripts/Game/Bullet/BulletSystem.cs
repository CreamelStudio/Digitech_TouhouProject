using System.Collections.Generic;
using UnityEngine;

public class BulletSystem {
	public static BulletSystem _instance;
	public static BulletSystem Get() => _instance;

	public List<Bullet>[] _bulletsByTeam = new List<Bullet>[2];

	private BulletPrefab _bulletPrefab;
	
	public BulletSystem() {
		_instance = this;

		_bulletsByTeam[0] = new List<Bullet>(96);
		_bulletsByTeam[1] = new List<Bullet>(512);

		_bulletPrefab = AssetManager.Get().GetPrefab("BulletPrefab").GetComponent<BulletPrefab>();
	}

	public void Dispose() {
		_instance = null;
	}
	public void LogicUpdate() {
		for (var team = 0; team < 2; team++) {
			var bullets = _bulletsByTeam[team];
			var bulletsCount = bullets.Count;
			for (var i = 0; i < bulletsCount; i++) {
				var bullet = bullets[i];
				bullet.LogicUpdate();
				if (bullet.isDestroyed) {
					bullets[i] = bullets[--bulletsCount];
					bullets.RemoveAt(i--);
					bullet.DestroyObject();
				}
			}
		}
	}

	private T SpawnBullet<T>(string sprite, int team, Vector2 position, Vector2 dir) where T : Bullet, new() {
		var bulletPrefab = Object.Instantiate(_bulletPrefab);
		bulletPrefab.SetSprite(AssetManager.Get().GetBulletSprite(sprite));
		
		var bullet = new T();
		bullet.Init(bulletPrefab);
		bullet.SetPosition(position);
		bullet.SetDir(dir);
		
		_bulletsByTeam[team].Add(bullet);
		return bullet;
	}
	
	public NormalBullet SpawnNormalBullet(string sprite, int team, Vector2 position, Vector2 dir, float speed) {
		var bullet = SpawnBullet<NormalBullet>(sprite, team, position, dir);
		bullet.SetSpeed(speed);

		return bullet;
	}
    public ReBullet SpawnReBullet(string sprite, int team, Vector2 position, Vector2 dir, float speed)
    {
        var bullet = SpawnBullet<ReBullet>(sprite, team, position, dir);
        bullet.SetSpeed(speed);

        return bullet;
    }

    public SlowBullet SpawnSlowBullet(string sprite, int team, Vector2 position, Vector2 dir, float speed)
    {
        var bullet = SpawnBullet<SlowBullet>(sprite, team, position, dir);
        bullet.SetSpeed(speed);

        return bullet;
    }

    public StopBullet SpawnStopBullet(string sprite, int team, Vector2 position, Vector2 dir, float speed)
    {
        var bullet = SpawnBullet<StopBullet>(sprite, team, position, dir);
        bullet.SetSpeed(speed);

        return bullet;
    }
}