namespace SkillAffactCase
{
    public interface ISkill { void SkillActivate(IAttacker attacker, IDefender defender); }

    public interface IDamagingSkill
    {
        int SkillDamageRatio { get; set; }
    }

    public interface IDebuffSkill
    {
        float LifeTime { get; set; }
    }

    public interface IBuffSkill
    {
        float LifeTime { get; set; }
    }
}