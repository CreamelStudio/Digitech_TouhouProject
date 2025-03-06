using UnityEngine;

public class EnemyUnit : Unit {
	public PatternSystem patternSystem;
    private DeadParticle1 _deadParticle1;

    private void Start()
    {
        _deadParticle1 = AssetManager.Get().GetPrefab("DeadParticle1").GetComponent<DeadParticle1>();
    }

    public void InitPattern(int patternValue)
	{
		switch (patternValue)
		{
			case 0:
				Invoke("DieWithOver", 5);
				break;
            case 1:
                Invoke("DieWithOver", 12);
                break;
            case 2:
                Invoke("DieWithOver", 5);
                break;
            case 3:
                Invoke("DieWithOver", 4);
                break;
            case 4:
                Invoke("DieWithOver", 4);
                break;
            case 5:
                Invoke("DieWithOver", 9);
                break;
        }
		patternSystem = new PatternSystem(patternValue, transform.position);
    }


	public override void UpdateMovement() {
		patternSystem.LogicUpdate();
		SetPosition(patternSystem.position);
    }

	public override void UpdateAttack() {
    }

	public override void HandleDamaged() {
        ScoreSystem._instance.score += 83;
		SoundManager.Get().PlaySound("se_damage00", 0.4f);
	}

	public override void HandleDead() {
        var powerPrefab = Object.Instantiate(_deadParticle1);
        powerPrefab.transform.position = position;
    }
}
