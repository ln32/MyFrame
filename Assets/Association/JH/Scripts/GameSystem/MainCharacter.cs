using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public int Level = 20;
    public EquipItemPlatform EquipItemPlatform;

    //public IBattlePropertyComposition AchievementSpec;
    public MainCharacter()
    {
        Level = 20;
        EquipItemPlatform = new EquipItemPlatform();
        //AchievementSpec = new BattlePropertyComposition();
    }

    public BattleClass BattleClass { get; set; } = new WarriorBattleClass();
}

public class BattleClass
{
}

public class WarriorBattleClass : BattleClass
{
}

public class ArcherBattleClass : BattleClass
{
}

public class MageBattleClass : BattleClass
{
}