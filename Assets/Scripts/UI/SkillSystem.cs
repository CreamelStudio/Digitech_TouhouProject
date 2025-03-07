using Unity.VisualScripting;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    public static SkillSystem _instance;

    public int skill;
    public GameObject[] countObj;

    private void Start()
    {
        _instance = this;
    }

    private void InitSkillStar()
    {
        for (int i = 0; i < 4; i++) countObj[i].SetActive(false);
        for(int i = 0; i < skill; i++) countObj[i].SetActive(true);
    }

    public void SkillAdd(int value)
    {
        skill += value;
        InitSkillStar();
    }

    public void SkillSet(int value)
    {
        skill = value;
        InitSkillStar();
    }
}
