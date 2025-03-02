using UnityEngine;

public class SlowBullet : Bullet {
	private float _speed;
	
	public override void LogicUpdate() {
		SetPosition(_position + _dir * (_speed * Time.deltaTime));
		
		if(!(_speed <= 80)) _speed -= 0.9f;
        if (CheckIfOutsideOfScreen())
			Destroy();
	}

	public void SetSpeed(float speed) {
		_speed = speed;
	}
}
