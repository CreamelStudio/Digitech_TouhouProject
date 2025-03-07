using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class GameSystem : MonoBehaviour {
    public static GameSystem _instance;
	private UnitSystem _unitSystem;
	private BulletSystem _bulletSystem;
	public CollisionSystem _collisionSystem;

	private void Start() {
        _instance = this;
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
        yield return new WaitForSeconds(6.5f);
        StartCoroutine(Pattern1());
        yield return new WaitForSeconds(6.5f);
        StartCoroutine(Pattern2());
        yield return new WaitForSeconds(6.5f);
        StartCoroutine(Pattern3());
        yield return new WaitForSeconds(6.5f);
        StartCoroutine(Pattern4());
        yield return new WaitForSeconds(6.5f);
        StartCoroutine(Pattern5());
        yield return new WaitForSeconds(6.5f);
        StartCoroutine(Pattern6());
        yield return new WaitForSeconds(6.5f);
        StartCoroutine(Pattern7());
        yield return new WaitForSeconds(6.5f);
        StartCoroutine(Pattern8());
        StartCoroutine(PatternUpdate());
    }

	IEnumerator PatternUpdate()
	{
        int random = UnityEngine.Random.Range(5, 10);
        yield return new WaitForSeconds(random);
        random = UnityEngine.Random.Range(0, 7);
        StartCoroutine("Pattern" + random.ToString());
		Debug.Log($"Pattern {random}");
		
			
		StartCoroutine(PatternUpdate());
    }

    #region pattern

    IEnumerator Pattern0()
	{
		Unit tempObj;
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-175, 300));
		tempObj.GetComponent<EnemyUnit>().InitPattern(0);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-175, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(0);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-175, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(0);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(175, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(0);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(175, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(0);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(175, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(0);
    }

    IEnumerator Pattern1()
    {
        Unit tempObj;
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(0, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(1);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(190, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(1);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-190, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(1);
    }
    IEnumerator Pattern2()
    {
        Unit tempObj;
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy2", Constants.Team.Enemy, new Vector2(-175, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(2);
        yield return new WaitForSeconds(0.6f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy2", Constants.Team.Enemy, new Vector2(175, 300));
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
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-175, 250));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-125, 250));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-175, 275));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-125, 275));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-175, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(-125, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(175, 250));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(125, 250));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(175, 275));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(125, 275));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(175, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy1", Constants.Team.Enemy, new Vector2(125, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(4);
    }

    IEnumerator Pattern5()
    {
        Unit tempObj;
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy2", Constants.Team.Enemy, new Vector2(-230, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(5);

        tempObj = _unitSystem.SpawnUnit("Unit_Enemy2", Constants.Team.Enemy, new Vector2(230, 300));
        tempObj.GetComponent<EnemyUnit>().InitPattern(5);

        yield return null;
    }

    IEnumerator Pattern6()
    {
        Unit tempObj;
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy_ToRight", Constants.Team.Enemy, new Vector2(-265, 200));
        tempObj.GetComponent<EnemyUnit>().InitPattern(6);
        yield return new WaitForSeconds(0.2f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy_ToRight", Constants.Team.Enemy, new Vector2(-265, 200));
        tempObj.GetComponent<EnemyUnit>().InitPattern(6);
        yield return new WaitForSeconds(0.2f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy_ToRight", Constants.Team.Enemy, new Vector2(-265, 200));
        tempObj.GetComponent<EnemyUnit>().InitPattern(6);
        yield return new WaitForSeconds(0.2f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy_ToRight", Constants.Team.Enemy, new Vector2(-265, 200));
        tempObj.GetComponent<EnemyUnit>().InitPattern(6);
        yield return new WaitForSeconds(0.2f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy_ToRight", Constants.Team.Enemy, new Vector2(-265, 200));
        tempObj.GetComponent<EnemyUnit>().InitPattern(6);
        yield return new WaitForSeconds(0.2f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy_ToRight", Constants.Team.Enemy, new Vector2(-265, 200));
        tempObj.GetComponent<EnemyUnit>().InitPattern(6);
        yield return new WaitForSeconds(0.2f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy_ToRight", Constants.Team.Enemy, new Vector2(-265, 200));
        tempObj.GetComponent<EnemyUnit>().InitPattern(6);
        yield return new WaitForSeconds(0.2f);


        tempObj = _unitSystem.SpawnUnit("Unit_Enemy_ToLeft", Constants.Team.Enemy, new Vector2(265, 200));
        tempObj.GetComponent<EnemyUnit>().InitPattern(6);
        yield return new WaitForSeconds(0.2f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy_ToLeft", Constants.Team.Enemy, new Vector2(265, 200));
        tempObj.GetComponent<EnemyUnit>().InitPattern(6);
        yield return new WaitForSeconds(0.2f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy_ToLeft", Constants.Team.Enemy, new Vector2(265, 200));
        tempObj.GetComponent<EnemyUnit>().InitPattern(6);
        yield return new WaitForSeconds(0.2f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy_ToLeft", Constants.Team.Enemy, new Vector2(265, 200));
        tempObj.GetComponent<EnemyUnit>().InitPattern(6);
        yield return new WaitForSeconds(0.2f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy_ToLeft", Constants.Team.Enemy, new Vector2(265, 200));
        tempObj.GetComponent<EnemyUnit>().InitPattern(6);
        yield return new WaitForSeconds(0.2f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy_ToLeft", Constants.Team.Enemy, new Vector2(265, 200));
        tempObj.GetComponent<EnemyUnit>().InitPattern(6);
        yield return new WaitForSeconds(0.2f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy_ToLeft", Constants.Team.Enemy, new Vector2(265, 200));
        tempObj.GetComponent<EnemyUnit>().InitPattern(6);
        yield return new WaitForSeconds(0.2f);

        yield return null;
    }

    IEnumerator Pattern7()
    {
        Unit tempObj;
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy2", Constants.Team.Enemy, new Vector2(-256, 77));
        tempObj.GetComponent<EnemyUnit>().InitPattern(7);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy2", Constants.Team.Enemy, new Vector2(-256, 77));
        tempObj.GetComponent<EnemyUnit>().InitPattern(7);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy2", Constants.Team.Enemy, new Vector2(-256, 77));
        tempObj.GetComponent<EnemyUnit>().InitPattern(7);
        yield return new WaitForSeconds(0.3f);
    }

    IEnumerator Pattern8()
    {
        Unit tempObj;
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy2", Constants.Team.Enemy, new Vector2(256, 77));
        tempObj.GetComponent<EnemyUnit>().InitPattern(8);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy2", Constants.Team.Enemy, new Vector2(256, 77));
        tempObj.GetComponent<EnemyUnit>().InitPattern(8);
        yield return new WaitForSeconds(0.3f);
        tempObj = _unitSystem.SpawnUnit("Unit_Enemy2", Constants.Team.Enemy, new Vector2(256, 77));
        tempObj.GetComponent<EnemyUnit>().InitPattern(8);
        yield return new WaitForSeconds(0.3f);
    }

    #endregion
}
