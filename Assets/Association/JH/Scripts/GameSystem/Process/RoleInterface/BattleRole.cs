using System.Collections.Generic;
using SkillAffactCase;
using SkillProcess;
using UnityEngine;
using static BattleEventProcessor;

public class CharacterBattleRole : IAttacker, IDefender
{
    private readonly List<IBattlePropertyComposition> specList = new();
    public MainGameCharacter character;
    public float LastAttackTime = 0;

    public CharacterBattleRole(MainGameCharacter _character, ICastingSkill iCastingSkillData = null)
    {
        character = _character;

        specList.Add(character.EquipItemPlatform);
        specList.Add(character.AchievementSpec);
        specList.Add(character.CharacterTypeSpec);

        ICastingSkillData = iCastingSkillData == null ? new Fireball() : iCastingSkillData;
        CurrentHP = (this as IBattleRole).GetProperty<MaxHP_BattleProperty>();
    }

    public int CurrentHP { get; set; }

    string IBattleRole.Name => character.name;

    public ICastingSkill ICastingSkillData { get; }

    int IBattleRole.GetProperty<T>()
    {
        int sum = 0;

        foreach (var item in specList)
        {
            sum += item != null ? item.GetProperty<T>() : 0;
        }

        return sum;
    }

    void IAttacker.CastAttack()
    {
        Debug.Log("CastAttack!!!");
        SkillCast.SkillCastProcess(this, ICastingSkillData);
    }
}