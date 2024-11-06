using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IRule
{
    bool IsAllowed(MainCharacter character, IEquipable item);
}


namespace RestrictionRules
{
    public class LevelRestrictionRule : IRule
    {
        private int requiredLevel;

        public LevelRestrictionRule(int level)
        {
            requiredLevel = level;
        }

        public bool IsAllowed(MainCharacter character, IEquipable item)
        {
            if (character.Level >= requiredLevel)
                return true;

            return false;
        }
    }



    public class ClassRestrictionRule : IRule
    {
        private List<Type> requiredClasses;

        public ClassRestrictionRule(params Type[] _requiredClasses)
        {
            requiredClasses = _requiredClasses.ToList();
        }

        public bool IsAllowed(MainCharacter character, IEquipable item)
        {
            if (requiredClasses.Any(requiredClass => requiredClass == character.BattleClass.GetType()))
                return true;

            return false;
        }
    }

}