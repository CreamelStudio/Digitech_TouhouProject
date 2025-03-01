using System.Collections.Generic;
using UnityEngine;

public class UnitSystem {
	public static UnitSystem _instnace;
	public static UnitSystem Get() => _instnace;
	
	public readonly List<Unit>[] _unitsByTeam = new List<Unit>[2];

	public UnitSystem() {
		_instnace = this;
		
		_unitsByTeam[0] = new List<Unit>(1);
		_unitsByTeam[1] = new List<Unit>();
	}

	public void Dispose() {
		_instnace = null;
	}

	public void LogicUpdate() {
		for (var team = 0; team < 2; team++) {
			var units = _unitsByTeam[team];
			var unitCount = units.Count;
			for (var i = 0; i < unitCount; i++) {
				var unit = units[i];
				unit.LogicUpdate();
				if (unit.isDestroyed) {
					units[i] = units[--unitCount];
					units.RemoveAt(i--);
					Object.Destroy(unit.gameObject);
				}
			}
		}
	}

	public Unit SpawnUnit(string prefab, int team, Vector2 position) {
		var unit = Object.Instantiate(AssetManager.Get().GetPrefab(prefab)).GetComponent<Unit>();
		_unitsByTeam[team].Add(unit);
		unit.Init();
		unit.SetPosition(position);

		return unit;
	}
}
