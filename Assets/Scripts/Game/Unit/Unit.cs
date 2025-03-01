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

	private void Awake() {
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
			Die();
		}

		HandleDamaged();
	}
	
	public abstract void HandleDamaged();

	public void Die() {
		isDestroyed = true;

		HandleDead();
	}

	public abstract void HandleDead();
}
