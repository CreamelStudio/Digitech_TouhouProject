using UnityEngine;

public class EnemyUnit : Unit {
	public PatternSystem patternSystem;

	public void InitPattern(int patternValue)
	{
		switch (patternValue)
		{
			case 0:
				Invoke("Die", 5);
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
	}

	public override void HandleDead() {
	}
}
