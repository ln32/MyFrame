using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class StageData
{
    public int maximumChapter = 10;
    public int maximumEpisode = 20;
    public int maximumStage = 5;
    public int maximumStageMonsterCount = 6;

    [Space(10)] public int currentLevel = 1; // 1 level = 10 chapter

    public int currentChapter = 1; // 1 chapter = 20 episode
    public int currentEpisode = 1; // 1 episode = 5 stage
    public int currentStage = 1; // 1 stage = 6 monster

    [Space(10)] public int bossTimer = 30;

    public void ClearStage()
    {
        currentStage++;

        if (currentStage > maximumStage)
        {
            currentStage = 1;
            ClearEpisode();
        }
    }

    private void ClearEpisode()
    {
        currentEpisode++;

        if (currentEpisode > maximumEpisode)
        {
            currentEpisode = 1;
            ClearChapter();
        }
    }

    private void ClearChapter()
    {
        currentChapter++;

        if (currentChapter > maximumChapter)
        {
            currentChapter = 1;
            ClearLevel();
        }
    }

    private void ClearLevel()
    {
        currentLevel++;
    }
}

public class StageManager : MonoBehaviour
{
    // TODO: FIXME: Dummy 나중에 지워야함.
    [SerializeField] private StageData dummyData;

    [field: Title("MainCharacter")] [SerializeField]
    private GameObject _mainCharacter;

    [field: Title("Prefab")] [SerializeField]
    private GameObject _objBossMonsterPrefa_Dummy;

    [SerializeField] private GameObject _objMonsterPrefab_Dummy = null;

    [field: Title("Transform")] [SerializeField]
    private Transform _trMonsterParent;

    [SerializeField] private float randomSpawnRange = 3;

    [SerializeField] private int _maxStageMonsterCount = 6; // 스테이지당 최대 몬스터 수

    private readonly List<GameObject> _spawnedMonsterList = new();

    private StageData _data = null;
    private int _killStageMonsterCount; // 스테이지당 처치한 몬스터 수

    public Action OnMonsterKilled;
    public static StageManager Instance { get; private set; }

    public IList<GameObject> SpawnedMonsterList => _spawnedMonsterList;
    public GameObject MainCharacter => _mainCharacter;

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

    private void Start()
    {
        Initialize(dummyData);
    }

    public void Initialize(StageData data)
    {
        _data = data;

        // 아래 주석 3줄은 아직 UI적용 안됨
        //Canvas_Main.instance.View.RoundInfoPanel.AcceleratorButton.AddEvent(OnAccelerator);
        //Canvas_Main.instance.View.RoundInfoPanel.BossButton.AddEvent(OnBoss);

        //Canvas_Main.instance.View.RoundInfoPanel.BossButton.gameObject.SetActive(false);
        // Canvas_Main.instance.View.RoundInfoPanel.RoundTimer.gameObject.SetActive(false);
        BuildStage();
    }

    private void OnAccelerator()
    {
        Debug.Log("OnAccelerator()");
    }

    private void OnBoss()
    {
        Debug.Log("OnBoss");

        _data.currentStage = 5;

        // Canvas_Main.instance.View.RoundInfoPanel.RoundSlider.SetRound_Immediately(_data.currentStage - 1);
        // Canvas_Main.instance.View.RoundInfoPanel.Timer(_data.bossTimer, OnBossTimerCallback);
        //
        // Canvas_Main.instance.View.RoundInfoPanel.RoundTimer.gameObject.SetActive(true);
        BuildStage();
    }

    private void OnBossTimerCallback()
    {
        if (_killStageMonsterCount < 1)
        {
            _data.currentStage = 1; // TEST
            BuildStage();
        }
    }

    private void BuildStage()
    {
        bool isBossRound = (_data.currentStage == 5) ? true : false;
        _maxStageMonsterCount = isBossRound ? 1 : _data.maximumStageMonsterCount;
        _killStageMonsterCount = 0;

        //UI 적용안됨
        //Canvas_Main.instance.View.RoundInfoPanel.BossButton.gameObject.SetActive(!isBossRound);
        // Canvas_Main.instance.View.RoundInfoPanel.RoundTimer.gameObject.SetActive(isBossRound);

        SetRound_UI();
        SpawnMonster(isBossRound, _maxStageMonsterCount);
    }

    private void SpawnMonster(bool isBossRound, int maxMonsterCount)
    {
        if (isBossRound) // boss stage
        {
            var obj = Instantiate(_objBossMonsterPrefa_Dummy, _trMonsterParent);
            obj.SetActive(true);
            _spawnedMonsterList.Add(obj);
            BossTimer().Forget();
            return;
        }

        for (int i = 0; i < maxMonsterCount; i++)
        {
            var obj = Instantiate(_objMonsterPrefab_Dummy, _trMonsterParent);
            Vector2 pos = Random.insideUnitCircle * randomSpawnRange;
            obj.transform.localPosition = pos;
            obj.SetActive(true);
            _spawnedMonsterList.Add(obj);
        }
    }

    private async UniTaskVoid BossTimer()
    {
        await UniTask.Delay(_data.bossTimer * 1000);
        OnBossTimerCallback();
    }

    /// <summary>
    /// 몬스터를 처치할 경우 호출
    /// </summary>
    public void KillMonster(GameObject mob)
    {
        _killStageMonsterCount++;
        _spawnedMonsterList.Remove(mob);
        OnMonsterKilled?.Invoke();
        StageClearCheck();
    }

    /// <summary>
    /// _killStageMonsterCount가 _m같axStageMonsterCount와 으면 다음 스테이지 몬스터 호출
    /// </summary>
    private void StageClearCheck()
    {
        if (_killStageMonsterCount == _maxStageMonsterCount)
        {
            _data.ClearStage();

            BuildStage();
        }
    }

    private void SetRound_UI()
    {
        // Canvas_Main.instance.View.RoundInfoPanel.Round(_data);
    }
}