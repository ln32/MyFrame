using System;
using UnityEngine;
using Object = UnityEngine.Object;

public static class ProjectileToEffectProcess
{
    /*
    public static void ProjectileProcess(out float reachTime)
    */

    public static void ProjectileProcess(InstantSkillData data, SkillCasterComponent caster, Vector3 targetV3,
        Action<Vector3> hitAction)
    {
        // 콜라이더 유무 분기점
        CastVisualComponent castVisual = data.isUpdate ? InstantType_MultiHit(caster) : InstantType_Default();

        // 값 초기화
        SetValue();

        // 적중 후 액션을 위한 할당
        castVisual.AddAction(hitAction);


        void SetValue()
        {
            Vector3 casterV3 = caster.transform.position + (Vector3)data.castPointCase;

            castVisual.transform.position = casterV3;

            castVisual.srcV3 = casterV3;
            castVisual.dstV3 = targetV3;

            castVisual.projectileSpeed = data.projectileSpeed;
            castVisual.SetReachTime();
        }
    }

    public static void ChainedProjectileProcess(InstantSkillData data, SkillCasterComponent caster, Vector3 targetV3,
        Action<Vector3> hitAction, Vector3 srcV3)
    {
        // 멀티 타겟용 함수
        CastVisualComponent castVisual = data.isUpdate ? InstantType_MultiHit(caster) : InstantType_Default();

        // 값 초기화
        SetValue();

        // 적중 후 액션을 위한 할당
        castVisual.AddAction(hitAction);


        void SetValue()
        {
            Vector3 casterV3 = caster.transform.position + (Vector3)data.castPointCase;

            castVisual.transform.position = srcV3;

            castVisual.srcV3 = srcV3;
            castVisual.dstV3 = targetV3;

            castVisual.projectileSpeed = data.projectileSpeed;
            castVisual.SetReachTime();
        }
    }


    private static CastVisualComponent InstantType_Default()
    {
        return Object.Instantiate(Dummy_SkillCasterFactory.Instance.singleTargetProjectile);
    }

    private static CastVisualComponent InstantType_MultiHit(SkillCasterComponent caster)
    {
        MultiTargetProjectile projectileComponent =
            Object.Instantiate(Dummy_SkillCasterFactory.Instance.multiTargetProjectile);
        projectileComponent.InitValue(caster.TargetingRule);
        return projectileComponent;
    }
}