using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem _instance;

    public int score;
    public SpriteRenderer[] count;

    public Sprite[] textImage;

    private void Start()
    {
        _instance = this;
    }

    private void FixedUpdate()
    {
        if(PlayerUnit._instance != null)
        {
            score += 173;
            InitScoreText();
        }
    }

    private void InitScoreText()
    {
        string formatScore = score.ToString("D9");
        for (int i = 0; i < count.Length; i++) count[i].sprite = textImage[int.Parse(formatScore[i].ToString())];
    }

    public void ScoreUp(int value)
    {
        score += value;
        InitScoreText();
    }
}
