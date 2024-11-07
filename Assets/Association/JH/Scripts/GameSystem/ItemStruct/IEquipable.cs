using System.Collections.Generic;
using System.Linq;
using UnityEngine.Rendering;

public interface IEquipable
{
    public string Name { get; }
    public SerializedDictionary<string, int> properties { get; }
    public List<IRule> RestrictionRules { get; }
    public EquipPart EquipPart { get; }


    public bool CanEquip(MainGameCharacter character)
    {
        return RestrictionRules.All(rule => rule.IsAllowed(character, this));
    }

    public void ApplyEquipSpec(IBattlePropertyComposition composition)
    {
        foreach (var item in properties)
        {
            composition.SetDelta(item.Key, item.Value);
        }
    }

    public void ApplyUnequipSpec(IBattlePropertyComposition composition)
    {
        foreach (var item in properties)
        {
            composition.SetDelta(item.Key, -item.Value);
        }
    }
}
