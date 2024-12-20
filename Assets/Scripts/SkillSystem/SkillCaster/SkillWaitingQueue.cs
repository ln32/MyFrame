public class SkillWaitingQueue
{
    public BattleSkill[] Queue;

    public SkillWaitingQueue(int count)
    {
        Queue = new BattleSkill[count];
    }

    public void Enqueue(int index, BattleSkill skill)
    {
        Queue[index] = skill;
    }

    public BattleSkill TryCastPrioritySkill()
    {
        // TODO : 스킬 우선순위 따지기.
        for (int index = 0; index < Queue.Length; index++)
        {
            var skill = Queue[index];

            if (skill == null || skill.IsNull())
                continue;

            // 시전에 성공 시 프로세스 아웃
            if (SkillCastProcess.IsCastable(skill))
            {
                var rtnSkill = Queue[index];
                Queue[index] = null;

                return rtnSkill;
            }
        }

        return null;
    }

    public BattleSkill TryCastSkillBySlotIndex(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= Queue.Length) return null;

        var skill = Queue[slotIndex];

        if (skill == null || skill.IsNull()) return null;


        // 시전에 성공 시 프로세스 아웃
        if (SkillCastProcess.IsCastable(skill))
        {
            var rtnSkill = Queue[slotIndex];
            Queue[slotIndex] = null;

            return rtnSkill;
        }

        return null;
    }
}