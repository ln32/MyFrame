using UnityEngine;
using Object = UnityEngine.Object;

public static class ProjectileToEffectProcess
{
    // TODO : 객체 풀링
    //private readonly ObjectPool<ProjectileComponent> _projectilePool;

    public static void ProjectileProcess(InstantSkillData data, SkillCasterComponent caster, Vector3 targetV3,
        out float reachTime)
    {
        ProjectileComponent projectileComponent = data.projectileComponent;
        float projectileSpeed = data.projectileSpeed;
        Vector3 CastPoint = data.castPointCase;
        Vector3 TargetPoint = data.targetPointCase;

        reachTime = 0.1f;

        Vector3 casterV3 = caster.Transform.position + CastPoint;

        ProjectileComponent projectile = Object.Instantiate(projectileComponent);
        projectile.transform.position = casterV3;

        // 타겟팅 방식에 따라 타겟을 설정 (예: 첫 번째 적)
        projectile.target = targetV3 + TargetPoint;
        projectile.projectileSpeed = projectileSpeed;
        reachTime = projectile.ReachTime;
    }
}