using System;
using UnityEngine;

[Serializable]
public class DefaultSkillFrame
{
    protected InstantSkillData Data;

    public DefaultSkillFrame()
    {
        Data = null;
        CastContext = null;
    }

    public DefaultSkillFrame(InstantSkillData data, int priorityIndex)
    {
        Data = data;
        PriorityIndex = priorityIndex;
        RecentCastTime = Time.time;
        CastContext = new CastContext(this);
    }

    public int Id => Data.id;
    public string SkillName => Data.skillName;

    public int PriorityIndex { get; set; }
    public float Cooldown => Data.cooldown;
    public float RecentCastTime { get; set; }


    public ProjectileComponent ProjectileComponent => Data.projectileComponent;
    public float ProjectileSpeed => Data.projectileSpeed;

    public float DamageRate => Data.damageRate;
    public float EffectRadius => Data.effectRadius;
    public int SearchCastTargetCount => Data.searchCastTargetCount;

    public bool IsDot => Data.isDot;
    public int RepeatCount => Data.repeatCount;
    public float TimeGap => Data.repeatCount;
    public int EffectOnRadiusTargetCount => Data.effectOnRadiusTargetCount;

    public Vector2 CastPointCase => Data.castPointCase;
    public Vector2 TargetPointCase => Data.targetPointCase;
    public TargetingCase TargetingCase => Data.targetingCase;
    public CastContext CastContext { get; set; }

    internal float RemainCoolDown => Mathf.Max(RecentCastTime + Cooldown - Time.time, 0);

    public bool IsNull()
    {
        return !Data;
    }

    public void SetNull()
    {
        Data = null;
    }

    public void CastCooldown(float currentTime)
    {
        RecentCastTime = currentTime;
    }

    /// <returns>
    ///     True - 해당 skill 쿨타임, 시전 불가 \n
    ///     False - 해당 skill 시전 가능
    /// </returns>
    public bool IsCoolingTime(float currentTime)
    {
        // currentTime < 0 = 생성시 쿨타임, 최초 시전에 쿨타임 비교 없음.
        if (RecentCastTime < 0)
            return false;

        return RecentCastTime + Cooldown > currentTime;
    }
}


public static class DefaultSkillCreateArray
{
    public static DefaultSkillFrame[] CreateArray(int size)
    {
        var array = new DefaultSkillFrame[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = new DefaultSkillFrame();
        }

        return array;
    }
}