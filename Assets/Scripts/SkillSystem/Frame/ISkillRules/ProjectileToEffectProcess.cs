using System;
using UnityEngine;
using Object = UnityEngine.Object;

public static class ProjectileToEffectProcess
{
    // TODO : 객체 풀링
    //private readonly ObjectPool<ProjectileComponent> _projectilePool;

    public static void ProjectileProcess(InstantSkillData data, SkillCasterComponent caster, Vector3 targetV3,
        out float reachTime)
    {
        Vector3 casterV3 = caster.transform.position + (Vector3)data.castPointCase;

        ProjectileComponent projectile = Object.Instantiate(Dummy_SkillCasterFactory.Instance.singleTargetProjectile);
        projectile.transform.position = casterV3;

        projectile.srcV3 = casterV3;
        projectile.dstV3 = targetV3;

        projectile.projectileSpeed = data.projectileSpeed;
        projectile.SetReachTime();
        reachTime = projectile.reachTime;
    }

    public static void ProjectileProcess(InstantSkillData data, SkillCasterComponent caster, Vector3 targetV3,
        Action<Vector3> hitAction)
    {
        Vector3 casterV3 = caster.transform.position + (Vector3)data.castPointCase;

        ProjectileComponent projectile = data.isUpdate
            ? MultiType(caster)
            : Object.Instantiate(Dummy_SkillCasterFactory.Instance.singleTargetProjectile);


        projectile.transform.position = casterV3;

        projectile.srcV3 = casterV3;
        projectile.dstV3 = targetV3;

        projectile.projectileSpeed = data.projectileSpeed;
        projectile.SetReachTime();
        projectile.AddAction(hitAction);
    }

    private static ProjectileComponent MultiType(SkillCasterComponent caster)
    {
        MultiTargetProjectile projectileComponent =
            Object.Instantiate(Dummy_SkillCasterFactory.Instance.multiTargetProjectile);
        projectileComponent.InitValue(caster.TargetingRule);
        return projectileComponent;
    }
}