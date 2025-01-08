public static class StageGUIEvent
{
    public static void ButtonEvent_SkillSlot(int index)
    {
        SkillCasterComponent caster = StageManager.Instance.MainCharacter.GetComponent<SkillCasterComponent>();
        SkillCastProcess.TryCastSlotSkill(caster, index);
    }

    public static void ButtonEvent_AutoSetting(bool value)
    {
        DummyAddOn_TryCasting caster = StageManager.Instance.MainCharacter.GetComponent<DummyAddOn_TryCasting>();
        caster.isAuto = value;
    }
}