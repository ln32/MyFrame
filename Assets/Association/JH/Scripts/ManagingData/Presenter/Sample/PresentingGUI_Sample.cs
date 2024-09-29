using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PresentingGUI_Sample : MonoBehaviour
{
    [SerializeField] internal List<GUI_EventSet> myMember;

    public iManagingDataHandler<DataEnum, int> _handler => DataManager.instance.DataEnum;

    private void Start()
    {
        foreach (var item in myMember)
        {
            _handler.SetObserving(item._dataEnum, item,true);
        }
    }

    // Disable 시 호출 등록
    private void OnEnable()
    {
        foreach (var item in myMember)
        {
            item._OnEnableAction?.Invoke();
        }
    }

    // Disable 시 호출 취소
    private void OnDisable()
    {
        foreach (var item in myMember)
        {
            item._OnDisableAction?.Invoke();
        }
    }
}
