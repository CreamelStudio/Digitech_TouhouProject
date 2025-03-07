using UnityEngine;
using UnityEngine.Video;

public class VideoToSprite : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public SpriteRenderer spriteRenderer;
    public RenderTexture renderTexture;
    private Texture2D texture2D;

    void Start()
    {
        texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);

        videoPlayer.targetTexture = renderTexture;
        videoPlayer.isLooping = true;
        videoPlayer.Play();
    }

    void Update()
    {
        if (videoPlayer.isPlaying)
        {
            RenderTexture.active = renderTexture;
            texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture2D.Apply();
            RenderTexture.active = null;

            Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));

            spriteRenderer.sprite = sprite;
        }
    }
}
