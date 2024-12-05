using Sirenix.OdinInspector;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DummySkillCast : MonoBehaviour
{
    // _TODO : Switch SkillData <-> Json   데이터 입출력
    [SerializeField] private SkillDataDictionary skillDataDictionary;
    [SerializeField] private DummySkillSlotViewModel vm;

    public DummySkillHero archer;
    public DummySkillHero monster;

    public bool IsAuto = true;

    // SkillSlotViewModel : dataModel - Platform - viewModel - gui   Skill Window
    [SerializeField] private SkillSlotPlatform skillSlotPlatform;

    private void Start()
    {
        if (archer is ISkillCastable skillCaster)
        {
            skillSlotPlatform = new SkillSlotPlatform(skillCaster, vm);

            // test env
            skillCaster.RegistSkill(1, new DefaultSkill(skillDataDictionary.GetSkillData(1)));
            skillCaster.RegistSkill(4, new DefaultSkill(skillDataDictionary.GetSkillData(4)));
        }
    }

    // 자동사냥 프로세스 대리
    private void Update()
    {
        skillSlotPlatform.UpdateFunc();

        if (IsAuto)
            archer.SkillWaitingQueue.TryCastPrioritySkill(archer.transform, monster.transform);
    }

    [Button]
    public void CastOnce()
    {
        archer.SkillWaitingQueue.TryCastPrioritySkill(archer.transform, monster.transform);
    }

    [Button]
    public void RegistSkill()
    {
        try
        {
            InstantSkillData skillData = skillDataDictionary.GetSkillData(Random.Range(1, 5));
            int slotIndex = Random.Range(0, 6);

            if (!skillData)
                throw new Exception();

            (archer as ISkillCastable).RegistSkill(slotIndex, new DefaultSkill(skillData));
        }
        catch (Exception e)
        {
            NabeDebug.Log(e + "");
        }
    }
}