using SkillAffactCase;
using UnityEngine;
public class DefaultAttack : ISkill, IDamagingSkill, ICastAnimationSkill
{
    public int SkillDamageRatio { get; set; } = 1;
    public float CastingDelay { get; set; } = 0.52f;
    public float RestoreDelay { get; set; } = 0.52f;
    public void SkillActivate(IAttacker attacker, IDefender defender)
    {
        Debug.Log($"{attacker.Name} is DefaultAttack to {defender.Name} / Damage : {attacker.GetProperty<ATK_BattleProperty>()}");
    }
}

public class Fireball : ISkill, IDamagingSkill, ICastAnimationSkill
{
    public int SkillDamageRatio { get; set; } = 12;
    public float CastingDelay { get; set; } = 0.52f;
    public float RestoreDelay { get; set; } = 0.52f;

    public void SkillActivate(IAttacker attacker, IDefender defender)
    {
        Debug.Log($"{attacker.Name} is cast fireball to {defender.Name} / Damage : {attacker.GetProperty<ATK_BattleProperty>() * SkillDamageRatio}");
    }
}
