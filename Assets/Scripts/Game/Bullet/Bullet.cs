using UnityEngine;

public abstract class Bullet {
	public bool isGraze;

	public Vector2 _position { get; protected set; }
	protected float _zOffset;
	protected Vector2 _dir;
	public bool isDestroyed { get; set; }
	
	protected BulletPrefab _bulletPrefab;
	public BulletPrefab bulletPrefab => _bulletPrefab;

	public void Init(BulletPrefab prefab) {
		isDestroyed = false;

		_zOffset = 0f;
		_bulletPrefab = prefab;
	}
	
	public abstract void LogicUpdate();

	protected bool CheckIfOutsideOfScreen() {
		return _position.x >= 370 || _position.x <= -370 || _position.y >= 290 || _position.y <= -290;
	}

	public void SetPosition(Vector2 pos) {
		_position = pos;
		_bulletPrefab.transform.position = new Vector3(pos.x, pos.y, _zOffset);
	}

	public void SetZOffset(float offset) {
		_zOffset = offset;
	}
	
	public void SetDir(Vector2 dir) {
		_dir = dir;
	}

	public void Destroy() {
		isDestroyed = true;
	}

	public void DestroyObject() {
		Object.Destroy(_bulletPrefab.gameObject);
	}
}
