using System;
using SkillAffactCase;
using UnityEngine;

namespace SkillProcess
{
    public static class SkillCast
    {
        public static void SkillCastProcess(IAttacker attacker, ICastingSkill iCastingSkill)
        {
            Action<IDefender> activation = (IDefender target) =>
            {
                SkillActivate.SkillActivateProcess(attacker,
                    (attacker as CharacterBattleRole).character as IDefender, iCastingSkill);
            };

            if (attacker is CharacterBattleRole && iCastingSkill is ICastAnimationSkill)
                AnimationProcess((attacker as CharacterBattleRole).character, iCastingSkill as ICastAnimationSkill,
                    () => activation(attacker as CharacterBattleRole));
        }

        static void AnimationProcess(IStateMachine attacker, ICastAnimationSkill skill, Action activation)
        {
            Debug.Log("AnimationProcess");
            attacker.GetStateMachine.Event_CastAttack(activation);
        }
    }

    public static class SkillActivate
    {
        /// <summary> 
        /// 예상 활용
        /// Action<IDefender> skillaction = (IDefender target) => { ActivateSkillProcess(attacker,target,skill); };
        /// </summary>
        public static bool SkillActivateProcess(IAttacker attacker, IDefender defender, ICastingSkill iCastingSkill)
        {
            if (iCastingSkill is IDamagingSkill)
                DamagingProcess(attacker, defender, iCastingSkill as IDamagingSkill);

            if (iCastingSkill is IDebuffSkill)
                DebuffProcess(attacker, defender, iCastingSkill as IDebuffSkill);

            if (iCastingSkill is IBuffSkill)
                BuffProcess(attacker, defender, iCastingSkill as IBuffSkill);

            // skill이 아무것도 상속 안할때를 생각하고 bool return, 그냥 void return 해야하나
            // (ex. 위 프로세스 하나도 해당 x)
            return iCastingSkill == null;
        }

        // TODO
        // 상대 존재
        // 스킬 최종 데미지 계산
        // 데미지 증감율 계산 (방어)
        // HP 감소 계산
        // 사망 판정
        static void DamagingProcess(IAttacker Attacker, IDefender Defender, IDamagingSkill DamagingSkill)
        {
            Debug.Log("DamagingProcess");
            //Defender.CurrentHP -= Attacker.GetProperty<ATK_BattleProperty>() * DamagingSkill.SkillDamageRatio;
        }

        static void DebuffProcess(IAttacker Attacker, IDefender Defender, IDebuffSkill DebuffSkill)
        {
            Debug.Log("DebuffProcess");
        }

        static void BuffProcess(IAttacker Attacker, IDefender Defender, IBuffSkill BuffSkill)
        {
            Debug.Log("BuffProcess");
        }
    }
}