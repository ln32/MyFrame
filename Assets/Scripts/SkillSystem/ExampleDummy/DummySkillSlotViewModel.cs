using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DummySkillSlotViewModel : MonoBehaviour, ISkillSlotViewModel
{
    [SerializeField] internal List<Image> cooldownImages;
    [SerializeField] internal List<TextMeshProUGUI> cooltimeTexts;
    [SerializeField] internal List<TextMeshProUGUI> skillTexts;

    public void ApplyCooltime_SkillSlotGUI(int i, float ratio, string text)
    {
        cooldownImages[i].fillAmount = ratio;
        cooltimeTexts[i].text = text;
    }

    public void ApplyDisableSkill_SkillSlotGUI(int i)
    {
        cooldownImages[i].fillAmount = 1;
        cooltimeTexts[i].text = "x";
    }
}