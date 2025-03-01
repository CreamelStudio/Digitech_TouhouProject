using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetManager {
	private static readonly AssetManager _instance = new();
	public static AssetManager Get() => _instance;

	private Dictionary<string, GameObject> _loadedPrefabs = new();
	private Dictionary<string, Sprite> _loadedSprites = new();
	private Dictionary<string, AudioClip> _loadedAudioClips = new();

	public GameObject GetPrefab(string key) {
		if (_loadedPrefabs.TryGetValue(key, out var go))
			return go;
		
		var handle = Addressables.LoadAssetAsync<GameObject>(key);
		go = handle.WaitForCompletion();
		if (handle.Status != AsyncOperationStatus.Succeeded) {
			Debug.LogError($"Prefab not found: {key}");
			return null;
		}
		
		_loadedPrefabs.Add(key, go);

		return go;
	}
	
	public Sprite GetBulletSprite(string key) {
		key = "Bullets[" + key + "]";
		if (_loadedSprites.TryGetValue(key, out var sprite))
			return sprite;
		
		var handle = Addressables.LoadAssetAsync<Sprite>(key);
		sprite = handle.WaitForCompletion();
		if (handle.Status != AsyncOperationStatus.Succeeded) {
			Debug.LogError($"Sprite not found: {key}");
			return null;
		}
		
		_loadedSprites.Add(key, sprite);

		return sprite;
	}
	
	public AudioClip GetAudioClip(string key) {
		if (_loadedAudioClips.TryGetValue(key, out var clip))
			return clip;
		
		var handle = Addressables.LoadAssetAsync<AudioClip>(key);
		clip = handle.WaitForCompletion();
		if (handle.Status != AsyncOperationStatus.Succeeded) {
			Debug.LogError($"AudioClip not found: {key}");
			return null;
		}
		
		_loadedAudioClips.Add(key, clip);

		return clip;
	}
}
