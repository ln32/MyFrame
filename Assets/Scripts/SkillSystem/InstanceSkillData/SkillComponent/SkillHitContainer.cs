using System;
using System.Collections.Generic;

[Serializable]
public class SkillHitContainer<T>
{
    private HashSet<T> _objectSet = new();

    public bool AddObject(T obj)
    {
        if (IsContain(obj))
        {
            return false;
        }

        if (true)
        {
            NabeDebug.Log($"{obj} added to the set.");
            _objectSet.Add(obj);
        }

        return true;
    }

    // 오브젝트 존재 여부 확인
    public bool IsContain(T obj)
    {
        return obj != null && _objectSet.Contains(obj);
    }
}