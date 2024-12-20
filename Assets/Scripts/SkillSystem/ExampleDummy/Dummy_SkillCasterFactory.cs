using UnityEngine;

public class Dummy_SkillCasterFactory : MonoBehaviour
{
    // _TODO : Switch SkillData <-> Json   데이터 입출력
    [SerializeField] public SkillDataDictionary skillDataDictionary;
    public static Dummy_SkillCasterFactory Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
            Instance = null;
        }

        if (Instance == null)
        {
            Instance = this;
        }
    }
}