using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem _instance;

    public int score;
    public int hiscore;
    public SpriteRenderer[] count;
    public SpriteRenderer[] Highcount;

    public Sprite[] textImage;

    private void Start()
    {
        hiscore = PlayerPrefs.GetInt("HiScore");
        InitHiScoreText();
        _instance = this;
    }

    private void FixedUpdate()
    {
        if(PlayerUnit._instance != null)
        {
            score += 173;
            if (score > hiscore) hiscore = score;
            InitScoreText();
            InitHiScoreText();
        }
    }

    private void InitScoreText()
    {
        string formatScore = score.ToString("D9");
        for (int i = 0; i < count.Length; i++) count[i].sprite = textImage[int.Parse(formatScore[i].ToString())];
    }

    private void InitHiScoreText()
    {
        string formatScore = hiscore.ToString("D9");
        for (int i = 0; i < Highcount.Length; i++) Highcount[i].sprite = textImage[int.Parse(formatScore[i].ToString())];
    }

    public void ScoreUp(int value)
    {
        score += value;
        InitScoreText();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("HiScore", hiscore);
    }
}
