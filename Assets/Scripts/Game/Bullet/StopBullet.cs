using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class StopBullet : Bullet {
	private float _speed;
	private float tempSpeed;

    private int shotCount;

	public override void LogicUpdate() {

		SetPosition(_position + _dir * (_speed * Time.deltaTime));
		shotCount++;

		if (shotCount == 90)
		{
            tempSpeed = _speed;
            _speed = 0;
        }
		if (shotCount == 150) _speed = tempSpeed;

        if (CheckIfOutsideOfScreen())
			Destroy();
	}

	public void SetSpeed(float speed) {
		_speed = speed;
	}
}
