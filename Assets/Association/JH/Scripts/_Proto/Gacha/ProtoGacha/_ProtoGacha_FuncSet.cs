using System;
using System.Collections.Generic;
using GachaAddactiveFuncset;
using ProtoGacha_Additional;
using UnityEngine;

namespace ProtoGacha_FuncSet
{
    internal class Handler_CardGacha : iGachaProcessHandler<FactoryData_MainGacha, ProductData_CardGacha>
    {
        public Handler_CardGacha(FactoryData_MainGacha input_myData, ProductData_CardGacha input_ResultData)
        {
            factoryData = input_myData;
            productData = input_ResultData;
        }

        public bool AvailableCheck()
        {
            return true;
        }

        public float[] GetRatioTable(FactoryData_MainGacha myData)
        {
            var temp = factoryData._fReader.GetData("Table_A");
            return temp.GetSnowballForm();
        }


        public ProductData_CardGacha SetProductData(int returnValue)
        {
            var fd = factoryData;

            if (productData == null) productData = new ProductData_CardGacha();

            productData.rtnIndex = returnValue;
            fd._cardData.Add(productData.rtnIndex);

            return productData;
        }

        public void SetSpendDelta()
        {
            //DataManager.instance.DataEnum.SetDelta(DataEnum.GoldCoin, +100);
            //Debug.Log("SetTicketDelta");
        }


        public void NotAvailableAction()
        {
            productData.ResultName = "NotAvailableAction";
        }

        public void SuccessAction_GUI(ProductData_CardGacha _ReturnData)
        {
            //Debug.Log("SuccessAction "  + _factoryData.gachaCombo + " / " + _factoryData.gachaStoreLevel);
        }

        #region impliement

        public FactoryData_MainGacha factoryData { get; }

        private ProductData_CardGacha productData;

        #endregion
    }

    internal class Handler_EquipItemGacha : iGachaProcessHandler<FactoryData_MainGacha, ProductData_EquipItem>
    {
        public Handler_EquipItemGacha(FactoryData_MainGacha input_myData, ProductData_EquipItem input_ResultData)
        {
            factoryData = input_myData;
            productData = input_ResultData;
        }

        public bool AvailableCheck()
        {
            if (factoryData._cardData.Count < 3)
                return false;

            return true;
        }

        // 확률 표 관리
        public float[] GetRatioTable(FactoryData_MainGacha myData)
        {
            var temp = factoryData._fReader.GetData("Table_B");
            return temp.GetSnowballForm();
        }

        // 자원 소모
        public void SetSpendDelta()
        {
            //DataManager.instance.DataEnum.SetDelta(DataEnum.GoldCoin, +1234);
            //Debug.Log("SetTicketDelta");
        }

        // 생성물 정보관리
        public ProductData_EquipItem SetProductData(int returnValue)
        {
            var fd = factoryData;

            if (productData == null) productData = new ProductData_EquipItem(factoryData);

            return productData;
        }

        // 실패연출
        public void NotAvailableAction()
        {
        }

        // 성공연출
        public void SuccessAction_GUI(ProductData_EquipItem _ReturnData)
        {
            Debug.Log("created item!");
        }

        #region impliement

        public FactoryData_MainGacha factoryData { get; }

        private ProductData_EquipItem productData;

        #endregion
    }

    [Serializable]
    public class ProductData_EquipItem
    {
        public Vector3Int _cardData;
        public int _GachaStoreLevel;
        public bool _isFever;

        public ProductData_EquipItem(FactoryData_MainGacha _slotData)
        {
            _cardData = ConvertListToVector3(_slotData._cardData);
            _GachaStoreLevel = _slotData.gachaStoreLevel;
            _isFever = _slotData.IsFeverTime;
        }

        private Vector3Int ConvertListToVector3(List<int> floatList)
        {
            // 예외 처리: 리스트의 요소 수가 3보다 적을 경우
            if (floatList == null) throw new ArgumentNullException(nameof(floatList), "The float list cannot be null.");

            if (floatList.Count < 3)
                throw new InvalidOperationException("The float list must contain at least 3 elements.");

            // 앞에서 3개의 float을 빼서 Vector3에 할당
            var x = floatList[0];
            var y = floatList[1];
            var z = floatList[2];

            // 필요 시 앞의 3개 요소를 리스트에서 제거
            floatList.RemoveRange(0, 3);

            return new Vector3Int(x, y, z);
        }
    }

    [Serializable]
    public class ProductData_CardGacha
    {
        public string ResultName;
        public int rtnIndex;
    }

    [Serializable]
    public class FactoryData_MainGacha
    {
        public XMLReader _fReader;
        public int gachaStoreLevel;
        public int gachaCombo;
        public float percent_Gacha;
        public List<int> _cardData;


        public bool isStored;

        private FeverHandler feverObj = new();
        public float FeverPer => feverObj.GetFeverPercent();
        public bool IsFeverTime => feverObj.IsFeverTime();

        public void AddFeverPercent_byCreateItem(ProductData_EquipItem item)
        {
            feverObj.AddFeverPercent_byCreateItem(1f / ((int)MathF.Max(gachaStoreLevel, 1) + 2));
            percent_Gacha = Mathf.Round(FeverPer * 100) / 100.0f;
            isStored = feverObj.GetIsStored();
        }
    }
}