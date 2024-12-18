using UnityEngine;
using Object = UnityEngine.Object;

public class EmptyEffectRule : IProjectileRule
{
    public Vector3 CastPoint { get; }
    public Vector3 TargetPoint { get; }

    public void GetTimeOnEffect(SkillCasterComponent caster, Vector3 targetPoint, out float reachTime)
    {
        reachTime = 0;
    }
}

public class ProjectileSkillRule : IProjectileRule
{
    // TODO : 객체 풀링
    //private readonly ObjectPool<ProjectileComponent> _projectilePool;
    private readonly ProjectileComponent _projectileComponent;
    private readonly float _projectileSpeed;

    public ProjectileSkillRule(DefaultSkillFrame skillData)
    {
        _projectileComponent = skillData.ProjectileComponent;
        _projectileSpeed = skillData.ProjectileSpeed;
        CastPoint = skillData.CastPointCase;
        TargetPoint = skillData.TargetPointCase;
    }


    public void GetTimeOnEffect(SkillCasterComponent caster, Vector3 targetV3, out float reachTime)
    {
        reachTime = 0.1f;

        Vector3 casterV3 = caster.Transform.position + CastPoint;

        ProjectileComponent projectile = Object.Instantiate(_projectileComponent);
        projectile.transform.position = casterV3;

        // 타겟팅 방식에 따라 타겟을 설정 (예: 첫 번째 적)
        projectile.target = targetV3 + TargetPoint;
        projectile.projectileSpeed = _projectileSpeed;
        reachTime = projectile.ReachTime;
    }

    public Vector3 CastPoint { get; }
    public Vector3 TargetPoint { get; }
}