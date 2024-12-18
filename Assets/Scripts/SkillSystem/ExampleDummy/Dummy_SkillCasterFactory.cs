using UnityEngine;

public class Dummy_SkillCasterFactory : MonoBehaviour
{
    // _TODO : Switch SkillData <-> Json   데이터 입출력
    [SerializeField] public SkillDataDictionary skillDataDictionary;
    public static Dummy_SkillCasterFactory Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
            Instance = null;
        }

        if (Instance == null)
        {
            Instance = this;
        }
    }

    /*
    public SkillCasterComponent archer;
    public SkillCasterComponent CreateMonster()
    {
        SkillCasterComponent _archer = Instantiate(archer);

        //_archer.RegistSkill(new DefaultSkill(skillDataDictionary.GetSkillData(3), 2));
        //_archer.RegistSkill(new DefaultSkill(skillDataDictionary.GetSkillData(4), 3));

        return _archer;
    }
    */
}