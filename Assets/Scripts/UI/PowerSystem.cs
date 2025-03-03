using UnityEngine;

public class PowerSystem : MonoBehaviour
{
    public static PowerSystem _instance;

    public int power;
    public Transform backgroundBoard;
    public SpriteRenderer[] count;

    public Sprite[] textImage;

    private void Start()
    {
        _instance = this;
    }

    private void InitScoreText()
    {
        string formatScore = power.ToString("D3");
        backgroundBoard.localScale = new Vector3((139.0901f / 100f) * power, 18.3f, 1);
        for (int i = 0; i < count.Length; i++) count[i].sprite = textImage[int.Parse(formatScore[i].ToString())];
    }

    public void PowerSet(int value)
    {
        power = value;
        InitScoreText();
    }
}
