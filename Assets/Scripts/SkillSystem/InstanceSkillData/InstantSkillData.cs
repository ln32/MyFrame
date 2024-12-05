using UnityEngine;

[CreateAssetMenu(fileName = "InstantSkillData", menuName = "Skill/InstantSkillData")]
public class InstantSkillData : ScriptableObject
{
    // 기본 정보
    public int id;
    public string skillName;

    public ProjectileComponent projectileComponent;

    public float coolTime;

    public int projectileSpeed;
    public Sprite projectileSprite;
    public Color projectileColor;
    public Vector2 projectileSize;

    // 이펙트
    //public GameObject trailEffect;
    //public GameObject explosionEffect;

    // 효과음
    //public AudioClip launchSound;
    //public AudioClip impactSound;
}