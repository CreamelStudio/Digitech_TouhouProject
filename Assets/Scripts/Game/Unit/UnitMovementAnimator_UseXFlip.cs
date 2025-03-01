using UnityEngine;

public class UnitMovementAnimator_UseXFlip : UnitMovementAnimator {
	public override void LogicUpdate() {
		if (Mathf.Abs(_sideMoveWeight) < 1f / (_sideMoveSprites.Length + 1)) {
			_spriteRenderer.sprite = _idleSprites[_currentFrame / 5 % _idleSprites.Length];
		} else if (Mathf.Abs(_sideMoveWeight) >= 1) {
			_spriteRenderer.sprite = _sideLoopSprites[_currentFrame / 5 % _sideLoopSprites.Length];
		} else {
			transform.localScale = new Vector3(-Mathf.Sign(_sideMoveWeight), 1, 1);
			_spriteRenderer.sprite = _sideMoveSprites[Mathf.FloorToInt(Mathf.Abs(_sideMoveWeight) * (_sideMoveSprites.Length + 1)) - 1];
		}

		_currentFrame++;
	}
}
