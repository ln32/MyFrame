using UnityEngine;

public class Dummy_AlwaysTryCasting : MonoBehaviour
{
    public SkillCasterComponent CoreCaster;
    public bool IsAuto = true;


    public bool initSkillRandom = true;

    private Transform _cash;

    private void Start()
    {
        if (initSkillRandom)
        {
            RegistSkill();
        }
    }


    // 자동사냥 프로세스 대리
    private void Update()
    {
        // 편의용 코드, 컴포넌트 자동연결 지향, 자동연결 시도 후에도 적합하지 않을 시 탈출,
        // 걍 required 써도 될듯...
        //if (IsAvailable() == false) return;

        if (IsAuto)
            SkillActivationProcess.TryCastSkillProcess(CoreCaster);
    }

    public void RegistSkill()
    {
        for (int i = 1; i < 5; i++)
        {
            InstantSkillData skillData = Dummy_SkillCasterFactory.Instance.skillDataDictionary.GetSkillData(i);

            CoreCaster.RegistSkill(new DefaultSkillFrame(skillData, i));
        }
    }

    private bool IsAvailable()
    {
        if (!CoreCaster)
        {
            if (_cash == transform)
            {
                return true;
            }

            CoreCaster = transform.GetComponent<SkillCasterComponent>();

            if (!CoreCaster)
            {
                return true;
            }
        }

        return false;
    }
}