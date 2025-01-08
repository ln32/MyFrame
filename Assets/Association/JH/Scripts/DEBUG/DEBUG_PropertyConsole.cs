using Sirenix.OdinInspector;
using UnityEngine;

public class DEBUG_PropertyConsole : MonoBehaviour
{
    public MainCharacter mc;
    public bp target;
    public command cmd;
    public int value;
    public IBattlePropertyComposition bpc;

    [Button]
    private void func()
    {
        bpc = mc.EquipItemPlatform;
        switch (cmd)
        {
            case command.SET:
                bpc.SetProperty(target.ToString(), value);
                break;
            case command.DELTA:
                bpc.SetDelta(target.ToString(), value);
                break;
            case command.GET:
                bpc.GetProperty(target.ToString());
                break;
            case command.REMOVE:
                bpc.RemoveProperty(target.ToString());
                break;
        }
    }


    [Button]
    private void equip()
    {
        var weapon = ItemFactory.CreateWeapon();
        EquipItemProcess.EquipItem(mc, weapon);

        var armor = ItemFactory.CreateArmor();
        EquipItemProcess.EquipItem(mc, armor);
    }

    [Button]
    private void equip2()
    {
        var weapon = ItemFactory.CreateWeapon2();
        EquipItemProcess.EquipItem(mc, weapon);

        var armor = ItemFactory.CreateArmor2();
        EquipItemProcess.EquipItem(mc, armor);
    }
}

public enum bp
{
    HP_BattleProperty,
    DEF_BattleProperty,
    ATK_BattleProperty,
    ATK_SPD_BattleProperty,
    Stun_BattleProperty,
    Evasion_BattleProperty,
    Regeneration_BattleProperty,
    Ignore_Stun_BattleProperty,
    Ignore_Evasion_BattleProperty,
    Ignore_Combo_BattleProperty,
    Ignore_Counter_BattleProperty,
    Crit_Dmg_BattleProperty,
    Crit_Res_BattleProperty,
    Basic_Atk_Dmg_BattleProperty,
    Basic_Atk_Res_BattleProperty,
    Combo_Dmg_BattleProperty,
    Combo_Res_BattleProperty,
    Counter_Dmg_BattleProperty,
    Counter_Res_BattleProperty,
    Launch_BattleProperty,
    Ignore_Launch_BattleProperty,
    Skill_Crit_Dmg_BattleProperty,
    Skill_Dmg_BattleProperty,
    Skill_Res_BattleProperty,
    Pal_Dmg_BattleProperty,
    Pal_Res_BattleProperty,
    Healing_Rate_BattleProperty,
    Healing_Amount_BattleProperty,
    Skill_CD_Reduction_BattleProperty,
    Wound_BattleProperty,
    Counter_Regen_BattleProperty,
    Combo_Regen_BattleProperty,
    Pal_Regen_BattleProperty,
    Skill_Regen_BattleProperty,
    Pal_Crit_Dmg_BattleProperty,
    Pal_Atk_Spd_BattleProperty,
    Pal_Ignore_Evasion_BattleProperty,
    Healing_Inc_Rate_BattleProperty,
    Special_Effect_BattleProperty
}

public enum command
{
    SET,
    GET,
    DELTA,
    REMOVE
}