using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PresentingGUI_Default : MonoBehaviour
{
    [SerializeField] internal List<ManagningGUI_SingleSprite> myGUI_ProfileSprite;

    [SerializeField] internal List<ManagningGUI_DataEnum> myGUI_DataEnum;
    internal iManagingDataHandler<DataEnum, int> _handler => DataManager.instance.DataEnum;

    internal List<ManagningGUI_SingleSprite> oldData_ProfileSprite = new();
    internal List<ManagningGUI_DataEnum> oldData_DataEnum = new();


    private void Start()
    {       
        // Start 시 호출 등록
        foreach (var item in myGUI_DataEnum)
        {
            _handler.SetObserving(item._dataEnum, item, item.OnInitInvoke);
            oldData_DataEnum.Add(item);
        }

        foreach (var item in myGUI_ProfileSprite)
        {
            DataManager.instance._ProfileData._profileImg.SetObserving(item, item.OnInitInvoke);
            oldData_ProfileSprite.Add(item);
        }
    }

    public void ReFresh()
    {
        // OnEnable시, myMember 순회돌며 호출 등록
        foreach (var item in oldData_DataEnum)
        {
            item._OnDisableAction?.Invoke();
        }
        foreach (var item in oldData_ProfileSprite)
        {
            item._OnDisableAction?.Invoke();
        }

        oldData_DataEnum.Clear();
        oldData_ProfileSprite.Clear();

        // Start 시 호출 등록
        foreach (var item in myGUI_DataEnum)
        {
            _handler.SetObserving(item._dataEnum, item, item.OnInitInvoke);
            oldData_DataEnum.Add(item);
        }

        foreach (var item in myGUI_ProfileSprite)
        {
            DataManager.instance._ProfileData._profileImg.SetObserving(item, item.OnInitInvoke);
            oldData_ProfileSprite.Add(item);
        }
    }

    private void OnEnable()
    {
        // OnEnable시, myMember 순회돌며 호출 등록
        foreach (var item in myGUI_DataEnum)
        {
            item._OnEnableAction?.Invoke();
        }       
        foreach (var item in myGUI_ProfileSprite)
        {
            item._OnEnableAction?.Invoke();
        }
    }


    private void OnDisable()
    {
        // Disable시, myMember 순회돌며 호출 취소
        foreach (var item in myGUI_DataEnum)
        {
            item._OnDisableAction?.Invoke();
        }
        foreach (var item in myGUI_ProfileSprite)
        {
            item._OnDisableAction?.Invoke();
        }
    }
}
