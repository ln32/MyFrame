using SkillAffactCase;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class DefaultSkill : IProjectileSkill, ICoolTimeSkill
{
    [SerializeField] private float recentCastTime;
    protected InstantSkillData Data;

    public DefaultSkill() { Data = null; }

    public DefaultSkill(InstantSkillData data)
    {
        Data = data;
        recentCastTime = -1;
    }

    float ICoolTimeSkill.CoolTime => Data.coolTime;

    float ICoolTimeSkill.RecentCastTime
    {
        get => recentCastTime;
        set => recentCastTime = value;
    }

    int ISkill.Id => Data.id;
    string ISkill.SkillName => Data.name;

    ProjectileComponent IProjectileSkill.GetInstantProjectileObject(Transform attacker, Transform defender)
    {
        ProjectileComponent projectileGame
            = Object.Instantiate(Data.projectileComponent, attacker.position, Quaternion.identity, attacker);

        ApplyProjectileData(defender, projectileGame);

        return projectileGame;
    }


    public bool IsNull()
    {
        return !Data;
    }

    public void SetNull()
    {
        Data = null;
    }

    private void ApplyProjectileData(Transform defender, ProjectileComponent projectileGame)
    {
        projectileGame.target = defender;

        if (projectileGame.projectileImage)
        {
            projectileGame.projectileImage.sprite = Data.projectileSprite;
            projectileGame.projectileImage.color = Data.projectileColor;
        }

        projectileGame.projectileSpeed = Data.projectileSpeed;
        projectileGame.transform.localScale = Data.projectileSize;
    }


    public void SetData(InstantSkillData data, float currTime = 0)
    {
        if (currTime == 0)
        {
            currTime = Time.time;
        }

        Data = data;

        recentCastTime = Data == null ? -2 : currTime;
    }

    public static DefaultSkill[] CreateArray(int size)
    {
        DefaultSkill[] array = new DefaultSkill[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = new DefaultSkill();
        }

        return array;
    }
}