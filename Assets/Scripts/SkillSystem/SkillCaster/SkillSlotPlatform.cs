using SkillAffactCase;
using UnityEngine;

public class SkillSlotPlatform
{
    private readonly ISkillCastable _targetCaster;
    private readonly ISkillSlotViewModel _vm;

    public SkillSlotPlatform(ISkillCastable caster, ISkillSlotViewModel vm)
    {
        _targetCaster = caster;
        _vm = vm;
    }

    // 외부에서 SkillSlotPlatform.Work() 로 빼야할지 고민중.
    public void UpdateFunc()
    {
        for (int i = 0; i < SkillSlots.Length; i++)
        {
            if (SkillSlots[i].IsNull())
            {
                _vm.ApplyDisableSkill_SkillSlotGUI(i);
                continue;
            }

            if (SkillSlots[i] is ICoolTimeSkill coolTimeSkill)
            {
                ApplyCooltime_SkillSlotView(coolTimeSkill, i);

                AddWaitingQueue(coolTimeSkill, i);
            }
        }
    }

    private void ApplyCooltime_SkillSlotView(ICoolTimeSkill coolTimeSkill, int i)
    {
        float ratio = coolTimeSkill.RemainCoolTime / coolTimeSkill.CoolTime;
        string text = coolTimeSkill.RemainCoolTime.ToString("F1");

        _vm.ApplyCooltime_SkillSlotGUI(i, ratio, text);
    }

    private void AddWaitingQueue(ICoolTimeSkill coolTimeSkill, int i)
    {
        if (coolTimeSkill.IsCoolingTime(Time.time) == false)
            WaitingQueue.Enqueue(i, SkillSlots[i]);
    }


    #region Macro

    private ISkillWaitingQueue WaitingQueue => _targetCaster.SkillWaitingQueue;
    private ISkill[] SkillSlots => _targetCaster.SkillSlots;

    #endregion
}

public interface ISkillWaitingQueue
{
    public void Enqueue(int index, ISkill skill);

    // TODO : attacker - defender 구체화. 아마 battlerole 관련
    public void TryCastPrioritySkill(Transform attacker, Transform defender);
}

public interface ISkillSlotViewModel
{
    void ApplyCooltime_SkillSlotGUI(int i, float ratio, string text);

    void ApplyDisableSkill_SkillSlotGUI(int i);
}