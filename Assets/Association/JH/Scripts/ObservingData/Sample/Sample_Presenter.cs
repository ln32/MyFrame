using DataSet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_Presenter : MonoBehaviour
{
    // Observe Data 참조, 나름 di랍시고 인터페이스로 제한
    DataManager actionController => DataManager.instance; 

    // 반응형 gui 스크립트 참조
    public Sample_GUI_ReactUnit reactGUI;

    // ObservingDataHandler에 초기값으로 name List를 넣어두고 해당 name 마다 각각의 변수-값을 생성
    private void Awake()
    {
    }
    private void OnEnable()
    {
        actionController.UserProfile.AddAction(UserProfileData.UserName, reactGUI.ReactFunc_UserNameSample, true);
        actionController.Currency.AddAction(CurrencyData.GoldCoin, reactGUI.ReactFunc_GoldSample, true);
        actionController.Currency.AddAction(CurrencyData.DiamondCoin, reactGUI.ReactFunc_DiaSample, true);
    }

    // 리스너 할당 해제 
    private void OnDisable()
    {
        actionController?.UserProfile.RemoveAction(UserProfileData.UserName, reactGUI.ReactFunc_UserNameSample);
        actionController?.Currency.RemoveAction(CurrencyData.GoldCoin, reactGUI.ReactFunc_GoldSample);
        actionController?.Currency.RemoveAction(CurrencyData.DiamondCoin, reactGUI.ReactFunc_DiaSample);
    }
}
