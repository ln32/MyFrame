using UnityEngine;

[CreateAssetMenu(fileName = "InstantSkillData", menuName = "Skill/InstantSkillData")]
public class InstantSkillData : ScriptableObject
{
    public int id;
    public string skillName;

    public float cooldown = -1f;

    public float damageRate = -1f;

    public float effectRadius = 0.1f;

    public int searchCastTargetCount = 1;

    public int effectOnRadiusTargetCount = 1;

    public bool isDot;
    public float tickRate = -1f;
    public int tickCount = 1;

    public float projectileSpeed = -1f;
    public ProjectileComponent projectileComponent;

    public int repeatCount = 1;
    public float repeatTimeGap = -1f;

    public Vector2 castPointCase;
    public Vector2 targetPointCase;

    public TargetingCase targetingCase = TargetingCase.First;
}