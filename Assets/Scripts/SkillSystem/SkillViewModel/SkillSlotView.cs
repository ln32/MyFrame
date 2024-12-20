using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlotView : MonoBehaviour
{
    [SerializeField] internal Toggle isAuto;

    [SerializeField] internal List<Image> cooldownImages;
    [SerializeField] internal List<TextMeshProUGUI> cooltimeTexts;
    [SerializeField] internal List<TextMeshProUGUI> skillTexts;
    [SerializeField] internal List<Button> skillButtons;

    private void Start()
    {
        for (int i = 0; i < skillButtons.Count; i++)
        {
            int index = i;
            skillButtons[i].onClick.AddListener(() => StageGUIEvent.ButtonEvent_SkillSlot(index));
        }

        if (isAuto)
        {
            isAuto.onValueChanged.AddListener(StageGUIEvent.ButtonEvent_AutoSetting);
        }
    }

    public void ApplyCooltime_SkillSlotGUI(int i, BattleSkill skill)
    {
        SkillSlotContainer data = new(skill);

        cooldownImages[i].fillAmount = data.ratio;
        cooltimeTexts[i].text = data.ratioText;
        skillTexts[i].text = data.skillName;
    }

    public void SetIsAuto(bool value)
    {
        if (isAuto)
        {
            isAuto.isOn = value;
        }
    }
}


public struct SkillSlotContainer
{
    public string skillName;
    public float ratio;
    public string ratioText;

    public SkillSlotContainer(BattleSkill skill)
    {
        if (skill.IsNull() == false)
        {
            skillName = skill.SkillName;
            ratio = skill.RemainCoolDown / skill.Cooldown;
            ratioText = skill.RemainCoolDown.ToString("F1");
        }
        else
        {
            skillName = "x";
            ratio = 0;
            ratioText = "x";
        }
    }
}