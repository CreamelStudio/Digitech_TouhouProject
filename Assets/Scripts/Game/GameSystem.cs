using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class GameSystem : MonoBehaviour {
	private UnitSystem _unitSystem;
	private BulletSystem _bulletSystem;
	private CollisionSystem _collisionSystem;

	private void Start() {
		Init();
	}

	private void OnDestroy() {
		Dispose();
	}

	private void Init() {
		_unitSystem = new UnitSystem();
		_bulletSystem = new BulletSystem();
		_collisionSystem = new CollisionSystem();


        SetUpPlayer();
		StartCoroutine(PatternUpdate());

    }

	public void Dispose() {
		_unitSystem.Dispose();
		_bulletSystem.Dispose();
	}

	private void SetUpPlayer() {
		_unitSystem.SpawnUnit("Unit_Player_Reimu", Constants.Team.Player, Vector2.zero);
	}

	private void SpawnTestEnemies() {
		_unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-200, 200));
		_unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(0, 200));
		_unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(200, 200));
	}
	
	private void FixedUpdate() {
		LogicUpdate();
	}

	private void LogicUpdate() {
		_unitSystem.LogicUpdate();
		_bulletSystem.LogicUpdate();
		_collisionSystem.LogicUpdate();

    }

	IEnumerator PatternUpdate()
	{
		yield return new WaitForSeconds(10);
		int random = UnityEngine.Random.Range(0, 2);
		Debug.Log($"Pattern {random}");
		switch (random)
		{
            case 0:
                StartCoroutine(Pattern0());
                break;
            case 1:
                StartCoroutine(Pattern1());
                break;
        }
			
		StartCoroutine(PatternUpdate());
    }

	IEnumerator Pattern0()
	{
		Unit tempObj;
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-200, 300));
		tempObj.GetComponent<EnemyUnit>().InitPattern(0);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-200, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(0);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-200, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(0);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(200, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(0);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(200, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(0);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(200, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(0);
    }

    IEnumerator Pattern1()
    {
        Unit tempObj;
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(0, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(1);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(200, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(1);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-200, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(1);
    }
}
