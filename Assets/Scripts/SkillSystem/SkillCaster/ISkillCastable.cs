using SkillAffactCase;
using System;

public interface ISkillCastable
{
    ISkill[] SkillSlots { get; }
    ISkillWaitingQueue SkillWaitingQueue { get; }

    public bool RegistSkill(int slotIndex, ISkill newData)
    {
        if (!CheckIndexRange(slotIndex))
            throw new ArgumentException("Index Error");

        // 기존 스킬 해제
        RemoveLegacy(newData.Id);

        // 새로이 할당
        SkillSlots[slotIndex] = newData;

        return true;
    }

    private void RemoveLegacy(int newSkillIndex)
    {
        for (int index = 0; index < SkillSlots.Length; index++)
        {
            ISkill skill = SkillSlots[index];
            if (skill.IsNull())
            {
                continue;
            }

            if (skill.Id == newSkillIndex)
            {
                SkillSlots[index] = new DefaultSkill();
            }
        }
    }

    private bool CheckIndexRange(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex > 5)
        {
            NabeDebug.Log("Invalid slot index.");
            return false;
        }

        return true;
    }
}