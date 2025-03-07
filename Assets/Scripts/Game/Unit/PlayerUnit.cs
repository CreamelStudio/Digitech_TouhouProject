using UnityEngine;

public class PlayerUnit : Unit {
	public static PlayerUnit _instance;
	public int power;
	public int powerUpCount;
	private int _attackCooldownTimer;
	private bool _isSlow;
    private DeadParticle1 _deadParticle1;
    private DeadParticle1 _bulletDeadParticle;
    private SkillParticle _skillParticle;
    public bool isGod;
	private SpriteRenderer sprite;

    private void Start()
    {
        SkillSystem._instance.SkillSet(4);
        _deadParticle1 = AssetManager.Get().GetPrefab("DeadParticle1").GetComponent<DeadParticle1>();
        _bulletDeadParticle = AssetManager.Get().GetPrefab("BulletDeadParticle").GetComponent<DeadParticle1>();
        _skillParticle = AssetManager.Get().GetPrefab("SkillParticle").GetComponent<SkillParticle>();
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
		PowerSystem._instance.PowerSet(power);
		_attackCooldownTimer--;
		if (_attackCooldownTimer > 0)
			return;
		
		if(powerUpCount % 2 == 1)
		{
            SoundManager.Get().PlaySound("se_powerup", 0.35f);
            powerUpCount++;
        }

		if (Input.GetKeyDown(KeyCode.X) && SkillSystem._instance.skill != 0 && !isGod)
		{
            SkillSystem._instance.SkillAdd(-1);
            var skillPrefab = Object.Instantiate(_skillParticle);
            isGod = true;
            sprite.color = new Color(1, 1, 1, 0.5f);
            Invoke("DisableGod", 3f);
            Invoke("SkillUse", 1f);
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
                    var enemyUnits = UnitSystem._instnace._unitsByTeam[Constants.Team.Enemy];
                    Vector2 dirVec = enemyUnits[Random.Range(0, enemyUnits.Count)].position - (new Vector2(transform.position.x, transform.position.y) + new Vector2(12, 0));
                    bullet = BulletSystem.Get().SpawnNormalBullet("Reimu_Amulet", Constants.Team.Player, position + new Vector2(-12, 0), dirVec, 800);
                    bullet.SetZOffset(1);
                    bullet.bulletPrefab.SetSpriteAlpha(0.5f);

                    bullet = BulletSystem.Get().SpawnNormalBullet("Reimu_Amulet", Constants.Team.Player, position + new Vector2(12, 0), dirVec, 800);
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

    public void SkillUse()
    {
        var enemyBullet = BulletSystem._instance._bulletsByTeam[Constants.Team.Enemy];
        for (int i = 0; i < enemyBullet.Count; i++)
        {
            var powerPrefab = Object.Instantiate(_bulletDeadParticle);
            powerPrefab.transform.position = enemyBullet[i]._position;
            enemyBullet[i].isDestroyed = true;
        }
        var enemyUnits = UnitSystem._instnace._unitsByTeam[Constants.Team.Enemy];
        for (int i = 0; i < enemyUnits.Count; i++) enemyUnits[i].DieWithPlayer();
    }

	public override void HandleDamaged() {
        SkillSystem._instance.SkillSet(4);
        Debug.Log("Player Damaged!");
		SoundManager.Get().PlaySound("se_pldead00", 0.6f);
		isGod = true;
        sprite.color = new Color(1, 1, 1, 0.5f);
        Invoke("DisableGod", 3f);
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
