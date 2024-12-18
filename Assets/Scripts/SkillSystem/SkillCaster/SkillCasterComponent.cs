using UnityEngine;

public class SkillCasterComponent : MonoBehaviour
{
    public Transform Transform => transform;
    public DefaultSkillFrame[] SkillSlots { get; set; } = DefaultSkillCreateArray.CreateArray(6);
    public SkillWaitingQueue SkillWaitingQueue { get; set; } = new SkillWaitingQueue(6);
    public Unitask_DelaySkillEnqueue DelayUnitask { get; } = new();

    private void Start()
    {
        for (int i = 0; i < SkillSlots.Length; i++)
        {
            if (SkillSlots[i].IsNull())
            {
                continue;
            }

            SkillSlots[i].PriorityIndex = i;
            SkillWaitingQueue.Enqueue(i, SkillSlots[i]);
        }
    }

    public bool RegistSkill(DefaultSkillFrame newData)
    {
        int slotIndex = -1;
        slotIndex = newData.PriorityIndex;

        if (!CheckIndexRange(slotIndex))
        {
            return false;
        }

        // 기존 스킬 해제
        RemoveLegacy(newData.Id);

        // 새로이 할당
        SkillSlots[slotIndex] = newData;
        SkillWaitingQueue.Enqueue(slotIndex, newData);

        return true;
    }

    public void ApplyCoolDown(DefaultSkillFrame coolTimeSkill)
    {
        DelayUnitask.DelayedAction(() =>
        {
            SkillWaitingQueue.Enqueue(coolTimeSkill.PriorityIndex, coolTimeSkill);
        }, coolTimeSkill.Cooldown).Forget();
    }


    private void RemoveLegacy(int newSkillIndex)
    {
        for (int index = 0; index < SkillSlots.Length; index++)
        {
            DefaultSkillFrame skill = SkillSlots[index];
            if (skill.IsNull())
            {
                continue;
            }

            if (skill.Id == newSkillIndex)
            {
                SkillSlots[index] = new DefaultSkillFrame();
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