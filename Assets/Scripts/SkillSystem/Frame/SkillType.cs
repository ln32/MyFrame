using SkillAffactCase;
using System.ComponentModel;
using UnityEngine;

public static class SkillActivate
{
    public static bool CastSkillProcess(Transform attacker, Transform defender, ISkill skill)
    {
        float time = Time.time;
        try
        {
            #region check_except

            if (skill is ICoolTimeSkill checkCooltime)
                checkCooltime.CheckCoolingTime(time);

            #endregion check_except

            #region process

            // 투사체 있을 시 투사체 생성
            if (skill is IProjectileSkill projectileSkill)
                CreateProjectileProcess(attacker, defender, projectileSkill);

            // 쿨타임 적용
            if (skill is ICoolTimeSkill coolTimeSkill)
                coolTimeSkill.CastCooldown(time);

            #endregion process

            return true;
        }
        catch { return false; }
    }

    private static void CreateProjectileProcess(Transform attacker, Transform defender,
        IProjectileSkill projectileSkill)
    {
        projectileSkill.GetInstantProjectileObject(attacker, defender);
    }
}

namespace SkillAffactCase
{
    public interface ISkill
    {
        int Id { get; }
        string SkillName { get; }
        bool IsNull();
        void SetNull();
    }

    public interface IProjectileSkill : ISkill
    {
        ProjectileComponent GetInstantProjectileObject(Transform attacker, Transform defender);
    }

    public interface ICoolTimeSkill : ISkill
    {
        float CoolTime { get; }
        float RecentCastTime { get; set; }

        float RemainCoolTime => Mathf.Max(RecentCastTime + CoolTime - Time.time, 0);

        void CastCooldown(float currentTime)
        {
            RecentCastTime = currentTime;
        }

        /// <returns>
        ///     True - 해당 skill 쿨타임, 시전 불가 \n
        ///     False - 해당 skill 시전 가능
        /// </returns>
        bool IsCoolingTime(float currentTime)
        {
            // currentTime < 0 = 생성시 쿨타임, 최초 시전에 쿨타임 비교 없음.
            if (RecentCastTime < 0)
                return false;

            return RecentCastTime + CoolTime > currentTime;
        }

        void CheckCoolingTime(float currentTime)
        {
            if (IsCoolingTime(currentTime))
                throw new WarningException($"is cooling on {RecentCastTime + CoolTime - currentTime}");
        }
    }
}