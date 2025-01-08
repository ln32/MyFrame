using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkillCasterComponent))]
public class DummyAddOn_EditableSkillSlot : MonoBehaviour
{
    [SerializeField] private List<int> skillList;
    [SerializeField] private bool initSkill = true;
    private SkillCasterComponent _coreCaster;

    private void Start()
    {
        _coreCaster = GetComponent<SkillCasterComponent>();
        if (initSkill)
        {
            RegistSkill();
        }
    }

    [Button]
    public void RegistSkill()
    {
        for (int i = 0; i < _coreCaster.SkillSlotCount; i++)
        {
            if (skillList[i] == 0)
            {
                continue;
            }

            _coreCaster.RegistSkill(
                new BattleSkill(Dummy_SkillCasterFactory.Instance.skillDataDictionary.GetSkillData(skillList[i]), i)
            );
        }
    }
}