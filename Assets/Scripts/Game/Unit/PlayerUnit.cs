using UnityEngine;

public class PlayerUnit : Unit {
	public static PlayerUnit _instance;
	public int power;
	public int powerUpCount;
	private int _attackCooldownTimer;
	private bool _isSlow;

	public bool isGod;
	private SpriteRenderer sprite;

	private PowerItem _powerItem;
    private PowerItem _bigPowerItem;

    private void Start()
    {
		_powerItem = AssetManager.Get().GetPrefab("PowerItem").GetComponent<PowerItem>();
        _bigPowerItem = AssetManager.Get().GetPrefab("BigPowerItem").GetComponent<PowerItem>();
		sprite = GetComponent<SpriteRenderer>();
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
		if (power <= 0) power = 0;
		if (power > 128) power = 128;
		PowerSystem._instance.PowerSet(power);
		_attackCooldownTimer--;
		if (_attackCooldownTimer > 0)
			return;
		
		if(powerUpCount % 2 == 1)
		{
            SoundManager.Get().PlaySound("se_powerup", 0.35f);
            powerUpCount++;
        }

        if (Input.GetKey(KeyCode.Z)) {
			if(power <= 49)
			{
                _attackCooldownTimer = 4;
                var bullet = BulletSystem.Get().SpawnNormalBullet("Reimu_Amulet", Constants.Team.Player, position, Vector2.up, 800);
                bullet.SetZOffset(1);
                bullet.bulletPrefab.SetSpriteAlpha(0.5f);
            }
			else if(power <= 89)
			{
                _attackCooldownTimer = 4;
				if (_isSlow)
				{
                    var bullet = BulletSystem.Get().SpawnNormalBullet("Reimu_Amulet", Constants.Team.Player, position + new Vector2(-5, 0), Vector2.up + new Vector2(0.05f, 0), 800);
                    bullet.SetZOffset(1);
                    bullet.bulletPrefab.SetSpriteAlpha(0.5f);

                    bullet = BulletSystem.Get().SpawnNormalBullet("Reimu_Amulet", Constants.Team.Player, position + new Vector2(5, 0), Vector2.up + new Vector2(0.05f, 0), 800);
                    bullet.SetZOffset(1);
                    bullet.bulletPrefab.SetSpriteAlpha(0.5f);
                }
				else
				{
                    var bullet = BulletSystem.Get().SpawnNormalBullet("Reimu_Amulet", Constants.Team.Player, position + new Vector2(-5, 0), Vector2.up, 800);
                    bullet.SetZOffset(1);
                    bullet.bulletPrefab.SetSpriteAlpha(0.5f);

                    bullet = BulletSystem.Get().SpawnNormalBullet("Reimu_Amulet", Constants.Team.Player, position + new Vector2(5, 0), Vector2.up, 800);
                    bullet.SetZOffset(1);
                    bullet.bulletPrefab.SetSpriteAlpha(0.5f);
                }

				if (powerUpCount == 0) powerUpCount++;
			}
			else
			{
                _attackCooldownTimer = 4;
                var bullet = BulletSystem.Get().SpawnNormalBullet("Reimu_Amulet", Constants.Team.Player, position + new Vector2(0, 0), Vector2.up, 800);
                bullet.SetZOffset(1);
                bullet.bulletPrefab.SetSpriteAlpha(0.5f);
                if (powerUpCount == 2) powerUpCount++;
                

                if (_isSlow)
				{
                    bullet = BulletSystem.Get().SpawnNormalBullet("Reimu_Amulet", Constants.Team.Player, position + new Vector2(-12, 0), Vector2.up, 800);
                    bullet.SetZOffset(1);
                    bullet.bulletPrefab.SetSpriteAlpha(0.5f);

                    bullet = BulletSystem.Get().SpawnNormalBullet("Reimu_Amulet", Constants.Team.Player, position + new Vector2(12, 0), Vector2.up, 800);
                    bullet.SetZOffset(1);

                }
				else {
                    bullet.bulletPrefab.SetSpriteAlpha(0.5f);
                    bullet = BulletSystem.Get().SpawnNormalBullet("Reimu_Amulet", Constants.Team.Player, position + new Vector2(-12, 0), Vector2.up + new Vector2(-0.08f, 0), 800);
                    bullet.SetZOffset(1);
                    bullet.bulletPrefab.SetSpriteAlpha(0.5f);

                    bullet = BulletSystem.Get().SpawnNormalBullet("Reimu_Amulet", Constants.Team.Player, position + new Vector2(12, 0), Vector2.up + new Vector2(0.08f, 0), 800);
                    bullet.SetZOffset(1);
                    bullet.bulletPrefab.SetSpriteAlpha(0.5f);
                }
            }
        }
	}

	public override void HandleDamaged() {
		
		if(power >= 10){
			power -= 10;
			SpawnPower(7);
		}
		else if(power != 0){
			power -= 3;
			SpawnPower(3);
		}
		Debug.Log("Player Damaged!");
		SoundManager.Get().PlaySound("se_pldead00", 0.6f);
		isGod = true;
        sprite.color = new Color(1, 1, 1, 0.5f);
        Invoke("DisableGod", 3f);
		
    }

	private void SpawnPower(int maxPowerCount){
		int randomTemp = Random.Range(2, maxPowerCount);
		for(int i=0;i< randomTemp; i++)
		{
			Vector3 randomVec = new Vector3(Random.Range(-40, 40), Random.Range(-20, 20), 0) + new Vector3(0, 180, 0);
            switch (Random.Range(0, 4))
            {
                case 0:
                    var powerPrefab = Object.Instantiate(_powerItem);
                    powerPrefab.SetPosition(transform.position + randomVec);
                    powerPrefab.SetSpeed(250);
                    break;
                case 1:
                    powerPrefab = Object.Instantiate(_powerItem);
                    powerPrefab.SetPosition(transform.position + randomVec);
                    powerPrefab.SetSpeed(250);
                    break;
				case 2:
                    powerPrefab = Object.Instantiate(_powerItem);
                    powerPrefab.SetPosition(transform.position + randomVec);
                    powerPrefab.SetSpeed(250);
                    break;
                case 3:
                    powerPrefab = Object.Instantiate(_bigPowerItem);
                    powerPrefab.SetPosition(transform.position + randomVec);
                    powerPrefab.SetSpeed(250);
                    break;
            }
        }
	}

	public void DisableGod()
	{
		isGod = false;
		sprite.color = new Color(1, 1, 1, 1);
    }

	public override void HandleDead() {
		ScoreSystem._instance.SaveScore();
        Destroy(this);
	}
}
