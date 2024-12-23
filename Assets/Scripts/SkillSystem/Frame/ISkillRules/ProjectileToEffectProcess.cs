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
        Vector3 castPoint = data.castPointCase;

        reachTime = 0.1f;

        Vector3 casterV3 = caster.transform.position + castPoint;

        ProjectileComponent projectile = Object.Instantiate(projectileComponent);
        projectile.transform.position = casterV3;

        // 타겟팅 방식에 따라 타겟을 설정 (예: 첫 번째 적)
        projectile.srcV3 = casterV3;
        projectile.dstV3 = targetV3;

        projectile.reachTime = projectileSpeed;
        reachTime = projectile.ReachTime;
    }

    public static void ProjectileProcess2(InstantSkillData data, SkillCasterComponent caster, Vector3 targetV3)
    {
        ProjectileComponent projectileComponent = data.projectileComponent;
        float projectileSpeed = data.projectileSpeed;
        Vector3 castPoint = data.castPointCase;
        Vector3 casterV3 = caster.transform.position + castPoint;

        ProjectileComponent projectile = Object.Instantiate(projectileComponent);
        projectile.transform.position = casterV3;

        // 타겟팅 방식에 따라 타겟을 설정 (예: 첫 번째 적)
        projectile.srcV3 = casterV3;
        projectile.dstV3 = targetV3;
        projectile.reachTime = projectileSpeed;
    }
}