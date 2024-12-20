using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "InstantSkillData", menuName = "Skill/InstantSkillData")]
public class InstantSkillData : ScriptableObject
{
    [field: Title("[ Base ]")] public int id;

    public int level;
    public int grade;
    public string skillName;

    [field: Title("[ Damage ]")] public float damageRate = -1f;

    [field: Title("[ DOT ]")] public bool isDot;

    public float tickRate = -1f;
    public int tickCount = 1;

    [field: Title("[ Cast ]")] public float cooldown = -1f;

    public int searchCastTargetCount = 1;

    [field: Title("[ Effect ]")] public float effectRadius = 0.1f;

    public int effectOnRadiusTargetCount = 1;

    [field: Title("[ Proj ]")] public float projectileSpeed = -1f;

    public ProjectileComponent projectileComponent;

    [field: Title("[ Loop ]")] public int loopCount = 1;

    public float loopTimeGap = -1f;


    // 의도 : 동적 소환 위치
    // 의도 : 피격 랜덤
    public Vector2 castPointCase;
    public Vector2 targetPointCase;
    public TargetingCase targetingCase = TargetingCase.First;
}