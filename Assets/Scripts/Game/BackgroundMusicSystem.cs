using UnityEngine;

public class BackgroundMusicSystem : MonoBehaviour
{
    private int bgmCount = 0;
    public AudioClip[] bgmList;
    private AudioSource audioSource;

    private void Start()
    {
        Application.runInBackground = true;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgmList[bgmCount];
        audioSource.Play();
    }

    private void FixedUpdate()
    {
        if (!audioSource.isPlaying)
        {
            bgmCount++;
            if(bgmList.Length == bgmCount) bgmCount = 0;
            audioSource.clip = bgmList[bgmCount];
            audioSource.Play();
        }
    }
}
