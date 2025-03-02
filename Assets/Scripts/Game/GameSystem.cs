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
        StartCoroutine(TestPatternUpdate());
		//StartCoroutine(PatternUpdate());

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

    IEnumerator TestPatternUpdate()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(Pattern0());
        yield return new WaitForSeconds(8);
        StartCoroutine(Pattern1());
        yield return new WaitForSeconds(8);
        StartCoroutine(Pattern2());
        yield return new WaitForSeconds(8);
        StartCoroutine(Pattern3());
        yield return new WaitForSeconds(8);
        StartCoroutine(Pattern4());
    }

	IEnumerator PatternUpdate()
	{
		yield return new WaitForSeconds(10);
		int random = UnityEngine.Random.Range(0, 3);
		Debug.Log($"Pattern {random}");
		switch (random)
		{
            case 0:
                StartCoroutine(Pattern0());
                break;
            case 1:
                StartCoroutine(Pattern1());
                break;
            case 2:
                StartCoroutine(Pattern2());
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
    IEnumerator Pattern2()
    {
        Unit tempObj;
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy2", Constants.Team.Enemy, new Vector2(-200, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(2);
        yield return new WaitForSeconds(0.6f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy2", Constants.Team.Enemy, new Vector2(200, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(2);
    }

    IEnumerator Pattern3()
    {
        Unit tempObj;
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy2", Constants.Team.Enemy, new Vector2(0, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(3);
        yield return null;
    }

    IEnumerator Pattern4()
    {
        Unit tempObj;
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-200, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-150, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-200, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-150, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-200, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-150, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(200, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(150, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(200, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(150, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(200, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(150, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
    }
}
