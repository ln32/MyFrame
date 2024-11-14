
using SkillAffactCase;
using System.Collections.Generic;
using UnityEngine;
using static BattleEventProcessor;

public class CharacterBattleRole : IAttacker, IDefender
{
    public int CurrentHP { get; set; }
    string IBattleRole.Name { get { return character.name; } }
    public ISkill SkillData { get; }

    public MainGameCharacter character;
    List<IBattlePropertyComposition> specList = new();
    public float LastAttackTime = 0;

    public CharacterBattleRole(MainGameCharacter _character, ISkill _SkillData = null)
    {
        character = _character;

        specList.Add(character.EquipItemPlatform);
        specList.Add(character.AchievementSpec);
        specList.Add(character.CharacterTypeSpec);

        SkillData = _SkillData == null ? new Fireball() : _SkillData;
        CurrentHP = (this as IBattleRole).GetProperty<MaxHP_BattleProperty>();
    }

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
        character.DelayedAction(1, (IDefender target) => { SkillData.SkillActivate(this, target); });
    }
}