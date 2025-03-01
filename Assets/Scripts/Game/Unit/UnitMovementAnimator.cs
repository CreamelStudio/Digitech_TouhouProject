using UnityEngine;

public abstract class UnitMovementAnimator : MonoBehaviour {
	[SerializeField] protected SpriteRenderer _spriteRenderer;
	[SerializeField] protected Sprite[] _idleSprites;
	[SerializeField] protected Sprite[] _sideMoveSprites;
	[SerializeField] protected Sprite[] _sideLoopSprites;

	protected float _sideMoveWeight;
	public float sideMoveWeight => _sideMoveWeight;
	
	protected Sprite[] _currentSprites;
	protected int _currentFrame;

	public abstract void LogicUpdate();

	public void SetSideMoveWeight(float weight) {
		_sideMoveWeight = weight;
	}

	public void AddSideMoveWeight(float weight) {
		_sideMoveWeight += weight;
		if (Mathf.Abs(_sideMoveWeight) > 1)
			_sideMoveWeight = Mathf.Sign(_sideMoveWeight);
	}
}
