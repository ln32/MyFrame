using UnityEngine;

[RequireComponent(typeof(SkillCasterComponent))]
public class DummyAddOn_TryCasting : MonoBehaviour
{
    public bool isAuto = true;
    private SkillCasterComponent _coreCaster;

    private void Start()
    {
        _coreCaster = GetComponent<SkillCasterComponent>();
    }

    // 자동사냥 프로세스 대리
    private void Update()
    {
        if (isAuto)
        {
            SkillCastProcess.TryCastSkillProcess(_coreCaster);
        }
    }
}