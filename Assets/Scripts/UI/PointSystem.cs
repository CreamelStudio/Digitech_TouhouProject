using Unity.VisualScripting;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public static PointSystem _instance;

    public int point;
    public int maxPoint;
    public SpriteRenderer[] count;
    public GameObject[] countObj;

    public Sprite[] textImage;

    private void Start()
    {
        _instance = this;
    }

    private void FixedUpdate()
    {
        InitScoreText();
    }

    private void InitScoreText()
    {
        string pointFormatScore = point.ToString();
        string maxPointFormatScore = maxPoint.ToString();
        string fullString = pointFormatScore + '/' + maxPointFormatScore;
        for (int i = 0; i < count.Length; i++)
        {
            if (fullString.Length - 1 < i) countObj[i].SetActive(false);
            else
            {
                countObj[i].SetActive(true);
                if (fullString[i] == '/') count[i].sprite = textImage[10];
                else count[i].sprite = textImage[int.Parse(fullString[i].ToString())];
            }
        }
    }

    public void pointAdd(int value)
    {
        point += value;
        InitScoreText();
    }

    public void pointSet(int value)
    {
        point = value;
        InitScoreText();
    }

    public void pointMaxAdd(int value)
    {
        maxPoint += value;
        InitScoreText();
    }

    public void pointMaxSet(int value)
    {
        maxPoint = value;
        InitScoreText();
    }
}
