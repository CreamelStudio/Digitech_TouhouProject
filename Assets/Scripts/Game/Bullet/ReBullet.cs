using UnityEngine;

public class ReBullet : Bullet {
	private float _speed;
	
	public override void LogicUpdate() {
		SetPosition(_position + _dir * (_speed * Time.deltaTime));
		_speed -= 2f;
		if (CheckIfOutsideOfScreen())
			Destroy();
	}

	public void SetSpeed(float speed) {
		_speed = speed;
	}
}
