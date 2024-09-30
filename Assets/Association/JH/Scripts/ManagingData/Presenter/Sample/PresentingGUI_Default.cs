using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PresentingGUI_Default : MonoBehaviour
{
    [SerializeField] internal List<ManagningGUI_Sample> myMember;

    public iManagingDataHandler<DataEnum, int> _handler => DataManager.instance.DataEnum;


    private void Start()
    {       
        // Start 시 호출 등록
        foreach (var item in myMember)
        {
            _handler.SetObserving(item._dataEnum, item, item.OnInitInvoke);
        }
    }


    private void OnEnable()
    {
        // OnEnable시, myMember 순회돌며 호출 등록
        foreach (var item in myMember)
        {
            item._OnEnableAction?.Invoke();
        }
    }


    private void OnDisable()
    {
        // Disable시, myMember 순회돌며 호출 취소
        foreach (var item in myMember)
        {
            item._OnDisableAction?.Invoke();
        }
    }
}
