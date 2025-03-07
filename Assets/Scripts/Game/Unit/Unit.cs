using UnityEditor;
using UnityEngine;

public abstract class Unit : MonoBehaviour {
	public int maxHp { get; private set; }
	public float _hp;
	public float _radius;
	public int hp => Mathf.CeilToInt(_hp);
	public Vector2 position { get; protected set; }
	
	public bool isDestroyed { get; private set; }

	protected UnitMovementAnimator _movementAnimator;
	public PowerItem _powerItem { get; private set; }
    public PowerItem _bigPowerItem { get; private set; }
    public ScoreItem _scoreItem { get; private set; }


    private void Awake() {
        _powerItem = AssetManager.Get().GetPrefab("PowerItem").GetComponent<PowerItem>();
        _bigPowerItem = AssetManager.Get().GetPrefab("BigPowerItem").GetComponent<PowerItem>();
        _scoreItem = AssetManager.Get().GetPrefab("ScoreItem").GetComponent<ScoreItem>();
        _movementAnimator = GetComponent<UnitMovementAnimator>();
	}
	
	public void Init() {
		isDestroyed = false;
	}

	public void SetMaxHp(int hp) {
		maxHp = hp;
		SetHp(hp);
	}

	public void LogicUpdate() {
		UpdateMovement();
		UpdateAttack();
		_movementAnimator.LogicUpdate();
	}

	public abstract void UpdateMovement();
	public abstract void UpdateAttack();
	
	public void SetHp(int hp) {
		_hp = hp;
	}

	public void SetPosition(Vector2 pos) {
		position = pos;
		transform.position = position;
	}

	public void Damaged(float damage) {
		_hp -= damage;
		if (_hp <= 0) {
            DieWithPlayer();
		}

		HandleDamaged();
	}
	
	public abstract void HandleDamaged();

    public void DieWithOver()
    {
        isDestroyed = true;
        HandleDead();
    }

    public void DieWithPlayer() {
        switch (Random.Range(0, 5))
        {


            case 0:
                var powerPrefab = Object.Instantiate(_powerItem);
                powerPrefab.SetPosition(transform.position );
                powerPrefab.SetSpeed(250);
                break;
            case 1:
                powerPrefab = Object.Instantiate(_powerItem);
                powerPrefab.SetPosition(transform.position );
                powerPrefab.SetSpeed(250);
                break;
            case 2:
                powerPrefab = Object.Instantiate(_bigPowerItem);
                powerPrefab.SetPosition(transform.position );
                powerPrefab.SetSpeed(250);
                break;
            case 3:
                var scorePrefab = Object.Instantiate(_scoreItem);
                scorePrefab.SetPosition(transform.position );
                scorePrefab.SetSpeed(250);
                PointSystem._instance.pointMaxAdd(1);
                break;
            case 4:
                scorePrefab = Object.Instantiate(_scoreItem);
                scorePrefab.SetPosition(transform.position );
                scorePrefab.SetSpeed(250);
                PointSystem._instance.pointMaxAdd(1);
                break;
        }

        
        isDestroyed = true;
        HandleDead();
	}

	public abstract void HandleDead();
}