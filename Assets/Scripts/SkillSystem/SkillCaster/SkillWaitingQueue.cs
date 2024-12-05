using SkillAffactCase;
using UnityEngine;

public class SkillWaitingQueue : ISkillWaitingQueue
{
    public ISkill[] Queue;

    public SkillWaitingQueue(int count)
    {
        Queue = new ISkill[count];
    }

    public void Enqueue(int index, ISkill skill)
    {
        Queue[index] = skill;
    }

    public void TryCastPrioritySkill(Transform attacker, Transform defender)
    {
        // TODO : 스킬 우선순위 따지기.
        for (int index = 0; index < Queue.Length; index++)
        {
            ISkill skill = Queue[index];

            if (skill == null || skill.IsNull())
                continue;

            // 시전에 성공 시 프로세스 아웃
            if (SkillActivate.CastSkillProcess(attacker, defender, skill))
            {
                Queue[index] = null;
                break;
            }
        }
    }
}