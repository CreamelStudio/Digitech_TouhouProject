using UnityEngine;

public class BulletPrefab : MonoBehaviour {
	[SerializeField] private SpriteRenderer _spriteRenderer;

	public void SetSprite(Sprite sprite) {
		_spriteRenderer.sprite = sprite;
	}

	public void SetSpriteAlpha(float alpha) {
		var color = _spriteRenderer.color;
		color.a = alpha;
		_spriteRenderer.color = color;
	}
}
