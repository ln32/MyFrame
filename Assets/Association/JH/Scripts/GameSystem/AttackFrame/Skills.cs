using SkillAffactCase;
using UnityEngine;

public class DefaultAttack : ICastingSkill, IDamagingSkill, ICastAnimationSkill
{
    public float CastingDelay { get; set; } = 0.52f;
    public float RestoreDelay { get; set; } = 0.52f;

    public void SkillActivate(IAttacker attacker, IDefender defender)
    {
        Debug.Log(
            $"{attacker.Name} is DefaultAttack to {defender.Name} / Damage : {attacker.GetProperty<ATK_BattleProperty>()}");
    }

    public int SkillDamageRatio { get; set; } = 1;
}

public class Fireball : ICastingSkill, IDamagingSkill, ICastAnimationSkill
{
    public float CastingDelay { get; set; } = 0.52f;
    public float RestoreDelay { get; set; } = 0.52f;

    public void SkillActivate(IAttacker attacker, IDefender defender)
    {
        Debug.Log(
            $"{attacker.Name} is cast fireball to {defender.Name} / Damage : {attacker.GetProperty<ATK_BattleProperty>() * SkillDamageRatio}");
    }

    public int SkillDamageRatio { get; set; } = 12;
}