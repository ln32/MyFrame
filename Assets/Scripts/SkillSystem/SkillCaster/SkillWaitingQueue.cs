public class SkillWaitingQueue
{
    public DefaultSkillFrame[] Queue;

    public SkillWaitingQueue(int count)
    {
        Queue = new DefaultSkillFrame[count];
    }

    public void Enqueue(int index, DefaultSkillFrame skill)
    {
        Queue[index] = skill;
    }

    public DefaultSkillFrame TryCastPrioritySkill()
    {
        // TODO : 스킬 우선순위 따지기.
        for (int index = 0; index < Queue.Length; index++)
        {
            var skill = Queue[index];

            if (skill == null || skill.IsNull())
                continue;

            // 시전에 성공 시 프로세스 아웃
            if (SkillActivationProcess.IsCastable(skill))
            {
                var rtnSkill = Queue[index];
                Queue[index] = null;

                return rtnSkill;
            }
        }

        return null;
    }
}