using System.Collections.Generic;
using UnityEngine;

public class PresentingGUI_Sample : MonoBehaviour
{
    [SerializeField] internal List<ManagingGUI_Sameple> myMember;

    public iManagingDataHandler<DataEnum, int> _handler => DataManager.instance.DataEnum;

    private void Start()
    {
        foreach (var item in myMember)
        {
            _handler.SetObserving(item._dataEnum, item);

            if(item.gameObject.activeSelf == false)
                item.gameObject.SetActive(true);
            else
                item.Reaction.Invoke(_handler.Get(item._dataEnum));
        }
    }
}
