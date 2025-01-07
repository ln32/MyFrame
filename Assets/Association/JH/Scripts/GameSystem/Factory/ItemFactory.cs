using RestrictionRules;

public static class ItemFactory
{
    public static Item CreateWeapon()
    {
        var item = new Item();

        item.Name = "CreatedWeapon";
        item.EquipPart = EquipPart.Weapon;

        item.SetOption("Default", typeof(ATK_BattleProperty).Name, 20);
        item.SetOption("Default", typeof(ATK_SPD_BattleProperty).Name, 10);
        item.SetOption("Default", typeof(MaxHP_BattleProperty).Name, 20);

        item.RestrictionRules.Add(new LevelRestrictionRule(10));
        item.RestrictionRules.Add(new ClassRestrictionRule(typeof(WarriorBattleClass)));

        return item;
    }

    public static Item CreateArmor()
    {
        var item = new Item();

        item.Name = "CreateArmor";
        item.EquipPart = EquipPart.Chestplate;

        item.SetOption("Default", typeof(DEF_BattleProperty).Name, 5);
        item.SetOption("Default", typeof(MaxHP_BattleProperty).Name, 15);

        item.RestrictionRules.Add(new LevelRestrictionRule(5));
        item.RestrictionRules.Add(new ClassRestrictionRule(typeof(WarriorBattleClass)));

        return item;
    }

    public static Item CreateWeapon2()
    {
        var item = new Item();

        item.Name = "CreatedWeapon2";
        item.EquipPart = EquipPart.Weapon;

        item.SetOption("Default", typeof(MaxHP_BattleProperty).Name, 20);
        item.SetOption("Default", typeof(MaxHP_BattleProperty).Name, 20);
        item.SetOption("Default", typeof(MaxHP_BattleProperty).Name, 20);

        item.RestrictionRules.Add(new LevelRestrictionRule(10));
        item.RestrictionRules.Add(new ClassRestrictionRule(typeof(WarriorBattleClass)));

        return item;
    }

    public static Item CreateArmor2()
    {
        var item = new Item();

        item.Name = "CreateArmor2";
        item.EquipPart = EquipPart.Chestplate;

        item.SetOption("Default", typeof(DEF_BattleProperty).Name, 100);
        item.SetOption("Default", typeof(DEF_BattleProperty).Name, 100);

        item.RestrictionRules.Add(new LevelRestrictionRule(5));
        item.RestrictionRules.Add(new ClassRestrictionRule(typeof(WarriorBattleClass)));

        return item;
    }
}