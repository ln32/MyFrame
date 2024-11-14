using SkillAffactCase;
using UnityEngine;
public class DefaultAttack : ISkill, IDamagingSkill
{
    public int SkillDamageRatio { get; set; } = 1;

    public void SkillActivate(IAttacker attacker, IDefender defender)
    {
        Debug.Log($"{attacker.Name} is DefaultAttack to {defender.Name} / Damage : {attacker.GetProperty<ATK_BattleProperty>()}");
    }
}

public class Fireball : ISkill, IDamagingSkill
{
    public int SkillDamageRatio { get; set; } = 12;


    public void SkillActivate(IAttacker attacker, IDefender defender)
    {
        Debug.Log($"{attacker.Name} is cast fireball to {defender.Name} / Damage : {attacker.GetProperty<ATK_BattleProperty>() * SkillDamageRatio}");
    }
}
