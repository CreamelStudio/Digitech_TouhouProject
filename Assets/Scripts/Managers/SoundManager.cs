using System.Collections.Generic;
using UnityEngine;

public class SoundManager {
	private static readonly SoundManager _instance = new();
	public static SoundManager Get() => _instance;

	private AudioSource _audioObject;

	private readonly List<AudioSource> _playingAudios = new();
	
	public SoundManager() {
		var go = new GameObject("AudioObject");
		Object.DontDestroyOnLoad(go);
		_audioObject = go.AddComponent<AudioSource>();
		go.SetActive(false);
	}
	
	public void PlaySound(string key) {
		ClearEndedSounds();
		
		var source = Object.Instantiate(_audioObject);
		source.clip = AssetManager.Get().GetAudioClip(key);
		source.gameObject.SetActive(true);
		
		_playingAudios.Add(source);
	}

	// 매니저 업데이트 돌리기 귀찮아서 그냥 Play할때마다 끝난 오디오 삭제해주기 ㅋㅋ
	public void ClearEndedSounds() {
		var count = _playingAudios.Count;
		for (var i = 0; i < count; i++) {
			var audio = _playingAudios[i];
			if (!audio.isPlaying) {
				_playingAudios[i] = _playingAudios[--count];
				_playingAudios.RemoveAt(i--);
				Object.Destroy(audio.gameObject);
			}
		}
	}

}
