using UnityEngine;

public class SkillCasterComponent : MonoBehaviour
{
    [SerializeField] private int skillSlotCount;
    [SerializeField] internal TeamType MyTeam = TeamType.Monster;
    public ITargetingRule TargetingRule;
    public int SkillSlotCount => skillSlotCount;
    public BattleSkill[] SkillSlots { get; set; }
    public SkillWaitingQueue SkillWaitingQueue { get; set; }
    public Unitask_DelaySkillEnqueue DelayUnitask { get; set; }

    private void Awake()
    {
        SkillSlots = DefaultSkillCreateArray.CreateArray(skillSlotCount);
        SkillWaitingQueue = new SkillWaitingQueue(skillSlotCount);
        DelayUnitask = new Unitask_DelaySkillEnqueue();
        TargetingRule = ITargetingRule.Get(MyTeam);
    }

    public bool RegistSkill(BattleSkill newData)
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

    public void ApplyCoolDown(BattleSkill coolTimeSkill)
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
            BattleSkill skill = SkillSlots[index];
            if (skill.IsNull())
            {
                continue;
            }

            if (skill.Id == newSkillIndex)
            {
                SkillSlots[index] = new BattleSkill();
            }
        }
    }

    private bool CheckIndexRange(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex > SkillSlotCount)
        {
            NabeDebug.Log("Invalid slot index.");
            return false;
        }

        return true;
    }
}