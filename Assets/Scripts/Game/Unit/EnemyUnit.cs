using UnityEngine;

public class EnemyUnit : Unit {
	public PatternSystem patternSystem;
    private DeadParticle1 _deadParticle1;

    public int summonBonusItemCount;
    public bool isDisablePatternSystemPosition;

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
            case 6:
                Invoke("DieWithOver", 5);
                isDisablePatternSystemPosition = true;
                break;
        }
		patternSystem = new PatternSystem(patternValue, transform.position);
    }


	public override void UpdateMovement() {
		patternSystem.LogicUpdate();
		if(!isDisablePatternSystemPosition) SetPosition(patternSystem.position);
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

        int randomTemp = Random.Range(2, 7);
        for (int i = 0; i < summonBonusItemCount; i++)
        {
            Vector3 randomVec = new Vector3(Random.Range(-40, 40), Random.Range(-20, 20), 0);
            switch (Random.Range(0, 5))
            {
                case 0:
                    var powerPrefabObj = Object.Instantiate(_powerItem);
                    powerPrefabObj.SetPosition(transform.position + randomVec);
                    powerPrefabObj.SetSpeed(250);
                    break;
                case 1:
                    powerPrefabObj = Object.Instantiate(_powerItem);
                    powerPrefabObj.SetPosition(transform.position + randomVec);
                    powerPrefabObj.SetSpeed(250);
                    break;
                case 2:
                    powerPrefabObj = Object.Instantiate(_bigPowerItem);
                    powerPrefabObj.SetPosition(transform.position + randomVec);
                    powerPrefabObj.SetSpeed(250);
                    break;
                case 3:
                    var scorePrefabObj = Object.Instantiate(_scoreItem);
                    scorePrefabObj.SetPosition(transform.position + randomVec);
                    scorePrefabObj.SetSpeed(250);
                    PointSystem._instance.pointMaxAdd(1);
                    break;
                case 4:
                    scorePrefabObj = Object.Instantiate(_scoreItem);
                    scorePrefabObj.SetPosition(transform.position + randomVec);
                    scorePrefabObj.SetSpeed(250);
                    PointSystem._instance.pointMaxAdd(1);
                    break;
            }
        }
    }
}
