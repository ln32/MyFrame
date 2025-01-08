using System.Collections.Generic;

public static class SkillHitContainerFunc
{
    /// <summary>
    ///     이미 맞았으면 false, 적중시 True
    /// </summary>
    /// <returns></returns>
    public static bool TryAddObject<T>(this HashSet<T> objectSet, T obj)
    {
        if (obj != null && objectSet.Contains(obj))
        {
            return false;
        }

        if (true)
        {
            NabeDebug.Log($"{obj} added to the set.");
            objectSet.Add(obj);
        }

        return true;
    }
}