using Unity.VisualScripting;
using UnityEngine;

public class GrazeSystem : MonoBehaviour
{
    public static GrazeSystem _instance;

    public int graze;
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
        string formatScore = graze.ToString();
        for (int i = 0; i < count.Length; i++)
        {
            if (formatScore.Length - 1 < i) countObj[i].SetActive(false);
            else
            {
                countObj[i].SetActive(true);
                count[i].sprite = textImage[int.Parse(formatScore[i].ToString())];
            }
        }
    }

    public void GrazeAdd(int value)
    {
        graze += value;
        InitScoreText();
    }

    public void GrazeSet(int value)
    {
        graze = value;
        InitScoreText();
    }
}
