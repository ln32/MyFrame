using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillDataDictionary", menuName = "Skill/SkillDataDictionary")]
public class SkillDataDictionary : ScriptableObject
{
    public List<InstantSkillData> skillProjectileDataSet;
    private readonly Dictionary<int, InstantSkillData> _dataSet = new();

    private void OnEnable()
    {
        _dataSet.Clear();

        foreach (InstantSkillData data in skillProjectileDataSet)
            _dataSet[data.id] = data;
    }

    public InstantSkillData GetSkillData(int index)
    {
        return _dataSet.GetValueOrDefault(index);
    }
}