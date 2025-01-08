using System.Collections.Generic;
using UnityEngine;

public class TriggerContext : MonoBehaviour
{
    public InstantSkillData TriggerSkill;
    public InstantSkillData ContainedSkill;

    public int myCount;
    // TODO :
    // 닿기전에 등록이 아닌 발사하며 등록 (1 - 2 - 4일 경우 중복 히트 발생)
    // 스킬취급 하게 만들기
    // 트리거의 트리거 고려
    // 데미지 감소 구현
    // 여러 분기 일관화 구조 고민

    private readonly HashSet<Vector3> _skillHitContainer = new();

    public void ExecuteTargeting(SkillCasterComponent caster)
    {
        _skillHitContainer.Clear();
        caster.DelayUnitask.RepeatedAction(
            () =>
            {
                ExecuteOnceSync(caster);
            },
            TriggerSkill.loopCount,
            TriggerSkill.loopTimeGap
        ).Forget();
    }

    private void ExecuteOnceSync(SkillCasterComponent caster)
    {
        // TODO ? _skillHitContainer 활용해서 대상 리스트 감소
        List<Vector3> targets =
            GetCastTargetingPointProcess.GetProcess(
                TriggerSkill,
                caster.TargetingRule.GetPositionsFromObjects()
            );

        // TODO : castCount / tick 계산 후 반복
        foreach (Vector3 targetPoint in targets)
        {
            if (_skillHitContainer.TryAddObject(targetPoint) == false)
            {
                return;
            }

            // With Instance Projectile 
            ProjectileToEffectProcess.ProjectileProcess(TriggerSkill, caster, targetPoint,
                point =>
                {
                    EffectContainerProcess.Process(TriggerSkill, caster, point);
                    ChainExecute(caster, 0, targetPoint);
                });
        }
    }

    private void ChainExecute(SkillCasterComponent caster, int index, Vector3 srcV3)
    {
        if (index >= myCount)
        {
            return;
        }

        List<Vector3> targets =
            GetCastTargetingPointProcess.GetProcess(
                ContainedSkill,
                caster.TargetingRule.GetPositionsFromObjects()
                //, _skillHitContainer
            );

        // TODO : castCount / tick 계산 후 반복
        foreach (Vector3 targetPoint in targets)
        {
            if (_skillHitContainer.TryAddObject(targetPoint) == false)
            {
                return;
            }

            // With Instance Projectile 
            ProjectileToEffectProcess.ChainedProjectileProcess(ContainedSkill, caster, targetPoint,
                point =>
                {
                    EffectContainerProcess.Process(ContainedSkill, caster, point);
                    ChainExecute(caster, index + 1, targetPoint);
                }, srcV3);
        }
    }
}