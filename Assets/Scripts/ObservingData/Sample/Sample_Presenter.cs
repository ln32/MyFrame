using DataSet;
using UnityEngine;

public class Sample_Presenter : MonoBehaviour
{
    // 반응형 gui 스크립트 참조
    public Sample_GUI_ReactUnit reactGUI;

    // Observe Data 참조, 나름 di랍시고 인터페이스로 제한
    private DataManager actionController => DataManager.instance;

    // ObservingDataHandler에 초기값으로 name List를 넣어두고 해당 name 마다 각각의 변수-값을 생성
    private void Awake()
    {
    }

    private void OnEnable()
    {
        actionController.STRING_UserProfile.AddAction(UserProfileData.UserName, reactGUI.ReactFunc_UserNameSample,
            true);
        actionController.INT_Currency.AddAction(CurrencyData.GoldCoin, reactGUI.ReactFunc_GoldSample, true);
        actionController.INT_Currency.AddAction(CurrencyData.DiamondCoin, reactGUI.ReactFunc_DiaSample, true);
    }

    // 리스너 할당 해제 
    private void OnDisable()
    {
        actionController?.STRING_UserProfile.RemoveAction(UserProfileData.UserName, reactGUI.ReactFunc_UserNameSample);
        actionController?.INT_Currency.RemoveAction(CurrencyData.GoldCoin, reactGUI.ReactFunc_GoldSample);
        actionController?.INT_Currency.RemoveAction(CurrencyData.DiamondCoin, reactGUI.ReactFunc_DiaSample);
    }
}