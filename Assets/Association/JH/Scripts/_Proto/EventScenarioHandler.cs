using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventScenarioHandler : MonoBehaviour
{
    [SerializeField] private int currentIndex;
    public List<CommandUnit> toggleList = new();
    public int cmdCount = 1;

    public void ExecuteNextEvent()
    {
        for (var i = 0; i < cmdCount; i++)
        {
            ChangeView();
            currentIndex = (currentIndex + 1) % toggleList.Count;
        }
    }

    private void ChangeView()
    {
        for (var i = 0; i < toggleList.Count; i++) toggleList[i].SetActiveFalse_Func();

        toggleList[currentIndex].InvokeFunc();
    }
}

[Serializable]
public class CommandUnit
{
    public string name;
    public List<GameObject> _goList;
    public UnityEvent _event;

    public void InvokeFunc()
    {
        _event?.Invoke();
        foreach (var item in _goList) item.SetActive(true);
    }

    public void SetActiveFalse_Func()
    {
        foreach (var item in _goList) item.SetActive(false);
    }
}