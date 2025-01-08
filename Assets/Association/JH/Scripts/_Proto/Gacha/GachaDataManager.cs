using System.Collections.Generic;
using ProtoGacha_FuncSet;
using UnityEngine;

public class GachaDataManager : MonoBehaviour
{
    [SerializeField] private FactoryData_MainGacha factoryData;

    [Space(10)] [SerializeField] public List<ProductData_EquipItem> myItems;

    private Handler_CardGacha _CardGachaHandler;
    private Handler_EquipItemGacha _EquipItemGacha;
    public iGachaProcessHandler<FactoryData_MainGacha, ProductData_CardGacha> gh_card => _CardGachaHandler;
    public iGachaProcessHandler<FactoryData_MainGacha, ProductData_CardGacha> gh_equip => _CardGachaHandler;

    [ContextMenu("InteractGacha")]
    public void InteractGacha()
    {
        ProductData_CardGacha insData = new();
        _CardGachaHandler = new Handler_CardGacha(factoryData, insData);
        gh_card.ExecuteGacha();
        _CardGachaHandler = null;
    }


    [ContextMenu("MergeItem_byCards")]
    public void MergeItem_byCards()
    {
        if (factoryData._cardData.Count < 3)
            return;

        var temp = new ProductData_EquipItem(factoryData);
        myItems.Add(temp);
        factoryData.AddFeverPercent_byCreateItem(temp);

        factoryData._cardData.Clear();
    }
}