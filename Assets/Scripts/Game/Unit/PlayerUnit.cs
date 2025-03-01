using UnityEngine;

public class PlayerUnit : Unit {
	public static PlayerUnit _instance;
	private int _attackCooldownTimer;
	private bool _isSlow;

    private void Start()
    {
		_instance = this;
    }

    public override void UpdateMovement() {
		var moveDir = Vector2.zero;
		if (Input.GetKey(KeyCode.RightArrow))
			moveDir.x += 1;
		if (Input.GetKey(KeyCode.LeftArrow))
			moveDir.x -= 1;
		if (Input.GetKey(KeyCode.UpArrow))
			moveDir.y += 1;
		if (Input.GetKey(KeyCode.DownArrow))
			moveDir.y -= 1;

		_isSlow = Input.GetKey(KeyCode.LeftShift);
		
		moveDir.Normalize();
		if (moveDir.x == 0) {
			_movementAnimator.AddSideMoveWeight(-Mathf.Sign(_movementAnimator.sideMoveWeight) * 7 * Time.deltaTime);
		} else {
			_movementAnimator.AddSideMoveWeight(moveDir.x * 7 * Time.deltaTime);
		}

		var newPos = position + moveDir * ((_isSlow ? 150 : 350) * Time.deltaTime);
		newPos.x = Mathf.Clamp(newPos.x, Constants.ScreenWidth * -0.5f + 10, Constants.ScreenWidth * 0.5f - 10);
		newPos.y = Mathf.Clamp(newPos.y, Constants.ScreenHeight * -0.5f + 10, Constants.ScreenHeight * 0.5f - 10);
		SetPosition(newPos);
	}

	public override void UpdateAttack() {
		_attackCooldownTimer--;
		if (_attackCooldownTimer > 0)
			return;
		
		if (Input.GetKey(KeyCode.Z)) {
			_attackCooldownTimer = 4;
			var bullet = BulletSystem.Get().SpawnNormalBullet("Reimu_Amulet", Constants.Team.Player, position, Vector2.up, 800);
			bullet.SetZOffset(1);
			bullet.bulletPrefab.SetSpriteAlpha(0.5f);
			SoundManager.Get().PlaySound("se_plst00");
		}
	}

	public override void HandleDamaged() {
		Debug.Log("Player Damaged!");
	}

	public override void HandleDead() {
		Destroy(this);
	}
}
