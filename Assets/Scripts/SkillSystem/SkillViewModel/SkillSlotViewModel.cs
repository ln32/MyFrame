using UnityEngine;

public class SkillSlotViewModel : MonoBehaviour
{
    // SkillSlotViewModel : model - vm - "view"
    [SerializeField] private SkillSlotView view;
    private DummyAddOn_TryCasting _autoModel;

    // SkillSlotViewModel : "model" - vm - view
    private SkillCasterComponent _model;

    private void Start()
    {
        _model ??= StageManager.Instance.MainCharacter.GetComponent<SkillCasterComponent>();
        _autoModel = _model.GetComponent<DummyAddOn_TryCasting>();
    }

    // 자동사냥 프로세스 대리
    private void Update()
    {
        // TODO : 추후에 observing으로 대체
        // sync view data
        SyncData();
    }

    public void SyncData()
    {
        if (view == null)
        {
            return;
        }

        if (_model == null)
        {
            return;
        }

        BattleSkill[] slots = _model.SkillSlots;
        for (int i = 0; i < slots.Length; i++)
        {
            view.ApplyCooltime_SkillSlotGUI(i, slots[i]);
            view.SetIsAuto(_autoModel.isAuto);
        }
    }
}