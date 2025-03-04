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
            case 1:
                Invoke("Die", 12);
                break;
            case 2:
                Invoke("Die", 5);
                break;
            case 3:
                Invoke("Die", 4);
                break;
            case 4:
                Invoke("Die", 4);
                break;
            case 5:
                Invoke("Die", 9);
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
		SoundManager.Get().PlaySound("se_damage00", 0.4f);
	}

	public override void HandleDead() {
	}
}
