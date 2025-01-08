using Sirenix.OdinInspector;
using UnityEngine;

public class DebugConsole_CastTriggerSkill : MonoBehaviour
{
    public TriggerContext context;
    public SkillCasterComponent caster;

    // 트리거 스킬은 아직 스킬이 아니기에 억지로 시전한다. 쿨타임도 존재하지 않음.
    [Button]
    public void RegistSkill()
    {
        context.ExecuteTargeting(caster);
    }
}