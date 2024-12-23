using Battle;
using System.Collections.Generic;
using UnityEngine;

public class SkillHitContainer : MonoBehaviour
{
    public List<Damageable> list = new();
    private HashSet<Damageable> _objectSet = new();

    internal IEventChecker EventChecker;


    private void Start()
    {
        _objectSet = new HashSet<Damageable>();
        list = new List<Damageable>();
    }


    private void Update()
    {
        IList<GameObject> instanceSpawnedMonsterList = StageManager.Instance.SpawnedMonsterList;
        foreach (GameObject monster in instanceSpawnedMonsterList)
        {
            Damageable damageable = monster.GetComponent<Damageable>();
            if (!damageable || ContainsObject(damageable))
            {
                continue;
            }

            if (EventChecker.Check(monster.transform.position))
            {
                AddObject(damageable);
            }
        }
    }

    public bool AddObject(Damageable obj)
    {
        if (ContainsObject(obj))
        {
            return false;
        }

        if (true)
        {
            NabeDebug.Log($"{obj.name} added to the set.");
            _objectSet.Add(obj);
            list.Add(obj);
        }

        return true;
    }

    // 오브젝트 존재 여부 확인
    public bool ContainsObject(Damageable obj)
    {
        return obj != null && _objectSet.Contains(obj);
    }
}

internal interface IEventChecker
{
    bool Check(Vector2 position);
}