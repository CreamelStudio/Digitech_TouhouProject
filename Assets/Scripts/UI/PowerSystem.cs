using UnityEngine;

public class PowerSystem : MonoBehaviour
{
    public static PowerSystem _instance;

    public int power;
    public Transform backgroundBoard;
    public Sprite[] maxImage; 
    public SpriteRenderer[] count;
    public GameObject[] countObj;

    public Sprite[] textImage;

    private void Start()
    {
        _instance = this;
    }

    private void InitScoreText()
    {
        if (power == 128) for(int i = 0; i < maxImage.Length; i++) count[i].sprite = maxImage[i];
        else
        {
            string formatScore = power.ToString();
            backgroundBoard.localScale = new Vector3((139.0901f / 100f) * power, 18.3f, 1);

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
    }

    public void PowerSet(int value)
    {
        power = value;
        InitScoreText();
    }
}
