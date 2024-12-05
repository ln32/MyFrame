using SkillAffactCase;
using UnityEngine;

public class DummySkillHero : MonoBehaviour, ISkillCastable
{
    public ISkill[] SkillSlots { get; set; } = DefaultSkill.CreateArray(6);
    public ISkillWaitingQueue SkillWaitingQueue { get; set; } = new SkillWaitingQueue(6);
}