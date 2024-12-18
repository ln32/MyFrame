using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlotView : MonoBehaviour
{
    [SerializeField] internal List<Image> cooldownImages;
    [SerializeField] internal List<TextMeshProUGUI> cooltimeTexts;
    [SerializeField] internal List<TextMeshProUGUI> skillTexts;

    public void ApplyCooltime_SkillSlotGUI(int i, DefaultSkillFrame skill)
    {
        SkillSlotContainer data = new(skill);

        cooldownImages[i].fillAmount = data.ratio;
        cooltimeTexts[i].text = data.ratioText;
        skillTexts[i].text = data.skillName;
    }
}


public struct SkillSlotContainer
{
    public string skillName;
    public float ratio;
    public string ratioText;

    public SkillSlotContainer(DefaultSkillFrame skill)
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