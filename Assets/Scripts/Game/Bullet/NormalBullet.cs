using UnityEngine;

public class NormalBullet : Bullet {
	private float _speed;
	
	public override void LogicUpdate() {
		SetPosition(_position + _dir * (_speed * Time.deltaTime));
		if (CheckIfOutsideOfScreen())
			Destroy();
	}

	public void SetSpeed(float speed) {
		_speed = speed;
	}
}
