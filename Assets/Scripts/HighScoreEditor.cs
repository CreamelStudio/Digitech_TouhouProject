using UnityEngine;
using UnityEngine.UI;

public class HighScoreEditor : MonoBehaviour
{
    public InputField fieldtext;
    public int hiScore;

    private void Start()
    {
        Debug.Log("Init HighScore");
        hiScore = PlayerPrefs.GetInt("HiScore");
        fieldtext.text = hiScore.ToString();
    }

    public void SaveHiScore()
    {
        Debug.Log("Save HighScore");
        PlayerPrefs.SetInt("HiScore", int.Parse(fieldtext.text));
    }
}
