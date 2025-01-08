using System;
using System.Collections.Generic;
using System.Linq;

public interface IEquipRestrictionRule
{
    bool IsAllowed(MainGameCharacter character, IEquipable item);
}


namespace EquipRestrictionRules
{
    public class LevelRestrictionRule : IEquipRestrictionRule
    {
        private int requiredLevel;

        public LevelRestrictionRule(int level)
        {
            requiredLevel = level;
        }

        public bool IsAllowed(MainGameCharacter character, IEquipable item)
        {
            if (character.Level >= requiredLevel)
                return true;

            return false;
        }
    }


    public class ClassRestrictionRule : IEquipRestrictionRule
    {
        private List<Type> requiredClasses;

        public ClassRestrictionRule(params Type[] _requiredClasses)
        {
            requiredClasses = _requiredClasses.ToList();
        }

        public bool IsAllowed(MainGameCharacter character, IEquipable item)
        {
            if (requiredClasses.Any(requiredClass => requiredClass == character.BattleClass.GetType()))
                return true;

            return false;
        }
    }

}