using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PresentingGUI_Sample : MonoBehaviour
{
    [SerializeField] internal List<ManagingGUI_Sameple> myMember;
    [SerializeField] internal List<GUI_EventSet> myMember2;

    public iManagingDataHandler<DataEnum, int> _handler => DataManager.instance.DataEnum;

    private void Start()
    {
        foreach (var item in myMember2)
        {
            _handler.SetObserving(item._dataEnum, item);

            if(item.gameObject.activeSelf == false)
                item.gameObject.SetActive(true);
            else
                item.Reaction.Invoke(_handler.Get(item._dataEnum));
        }
    }
}
