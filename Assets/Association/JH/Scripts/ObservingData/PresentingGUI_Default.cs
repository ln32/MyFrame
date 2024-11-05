using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PresentingGUI_Default : MonoBehaviour
{
    [SerializeField] internal List<ManagningGUI_SingleSprite> myGUI_ProfileSprite;

    [SerializeField] internal List<ManagningGUI_DataEnum> myGUI_DataEnum;
    internal iManagingDataHandler<DataEnum, int> _handler => DataManager.instance.DataEnum;

    internal List<Action> oldData = new();

    public void Refresh()
    {
        OnDisableAction();

        oldData.Clear();

        OnEnableAction();
    }

    private void OnEnableAction()
    {
        oldData.Clear();

        // Start 시 호출 등록
        foreach (var item in myGUI_DataEnum)
        {
            _handler.SetObserving(item._dataEnum, item, item.OnInitInvoke);
            oldData.Add(item._OnDisableAction);
        }

        foreach (var item in myGUI_ProfileSprite)
        {
            DataManager.instance._ProfileData._profileImg.SetObserving(item, item.OnInitInvoke);
            oldData.Add(item._OnDisableAction);
        }
    }


    private void OnDisableAction()
    {
        // Disable시, myMember 순회돌며 호출 취소
        foreach (var item in oldData)
        {
            Debug.Log(item == null);
            item?.Invoke();
        }
    }


    private void OnEnable()
    {
        OnEnableAction();
    }
    private void OnDisable()
    {
        OnDisableAction();
    }

}
