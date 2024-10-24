using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_Presenter : MonoBehaviour
{
    // Observe Data 참조, 나름 di랍시고 인터페이스로 제한
    iActionHandler _actionController => data; public ObservingDataHandler data;

    // 반응형 gui 스크립트 참조
    public Sample_GUI_ReactUnit reactGUI;

    // ObservingDataHandler에 초기값으로 name List를 넣어두고 해당 name 마다 각각의 변수-값을 생성
    private void Awake()
    {
        data.AwakeFunc();
    }

    // 리스너 할당
    private void OnEnable()
    {
        _actionController.AddAction<string>("UserName", reactGUI.ReactFunc_UserNameSample, false);
        _actionController.AddAction<int>("Gold", reactGUI.ReactFunc_GoldSample, true);
        _actionController.AddAction<int>("Diamond", reactGUI.ReactFunc_DiaSample, true);
    }

    // 리스너 할당 해제 
    private void OnDisable()
    {
        _actionController.RemoveAction<string>("UserName", reactGUI.ReactFunc_UserNameSample);
        _actionController.RemoveAction<int>("Gold", reactGUI.ReactFunc_GoldSample);
        _actionController.RemoveAction<int>("Diamond", reactGUI.ReactFunc_DiaSample);
    }
}
