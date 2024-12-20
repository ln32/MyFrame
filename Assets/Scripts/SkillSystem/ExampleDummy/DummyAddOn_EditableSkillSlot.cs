using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkillCasterComponent))]
public class DummyAddOn_EditableSkillSlot : MonoBehaviour
{
    [SerializeField] private List<int> skillList;

    public bool initSkillRandom = true;
    private SkillCasterComponent _coreCaster;

    private void Start()
    {
        _coreCaster = GetComponent<SkillCasterComponent>();
        RegistSkill();
    }

    [Button]
    public void RegistSkill()
    {
        for (int i = 0; i < 6; i++)
        {
            if (skillList[i] == 0)
            {
                continue;
            }

            InstantSkillData skillData =
                Dummy_SkillCasterFactory.Instance.skillDataDictionary.GetSkillData(skillList[i]);

            _coreCaster.RegistSkill(new BattleSkill(skillData, i));
        }
    }
}