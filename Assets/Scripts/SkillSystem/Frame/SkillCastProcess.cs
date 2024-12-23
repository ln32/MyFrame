using UnityEngine;

public static class SkillCastProcess
{
    public static bool IsCastable(BattleSkill skill)
    {
        if (skill.IsCoolingTime(Time.time)) return false;

        return true;
    }

    public static void TryCastSkillProcess(SkillCasterComponent caster)
    {
        BattleSkill skill = caster.SkillWaitingQueue.TryCastPrioritySkill();

        if (skill == null)
        {
            return;
        }

        CastProcess(caster, skill);
    }

    public static void TryCastSlotSkill(SkillCasterComponent caster, int index)
    {
        BattleSkill skill = caster.SkillWaitingQueue.TryCastSkillBySlotIndex(index);

        if (skill == null)
        {
            NabeDebug.Log("Skill Is NUll");
            return;
        }

        CastProcess(caster, skill);
    }

    private static void CastProcess(SkillCasterComponent caster, BattleSkill skill)
    {
        // cast 시전
        skill.CastContext.ExecuteTargeting(caster);

        // waiting queue관련
        caster.ApplyCoolDown(skill);

        // 슬롯 ui를 위해 스킬 최근 스킬 시전 갱신 
        skill.CastCooldown(Time.time);
    }
}