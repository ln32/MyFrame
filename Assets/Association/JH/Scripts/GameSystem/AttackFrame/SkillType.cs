namespace SkillAffactCase
{
    public interface ISkill { 
        void SkillActivate(IAttacker attacker, IDefender defender); 
    }

    public interface IStateDamageSkill { }

    public interface ICoolTimeSkill { float CoolTime{ get; set; } }

    public interface ICastAnimationSkill 
    { 
        float CastingDelay{ get; set; }
        float RestoreDelay { get; set; }
    }

    public interface IDamagingSkill
    {
        int SkillDamageRatio { get; set; }
    }

    public interface IDebuffSkill
    {
        float DebuffLifeTime { get; set; }
    }

    public interface IBuffSkill
    {
        float BuffLifeTime { get; set; }
    }
}