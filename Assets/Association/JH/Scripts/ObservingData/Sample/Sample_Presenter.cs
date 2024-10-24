using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_Presenter : MonoBehaviour
{
    iActionHandler _actionController => data; public ObservingDataHandler data;
    public Sample_GUI_ReactUnit reactGUI;

    // Start is called before the first frame update
    private void Awake()
    {
        data.AwakeFunc();
    }

    private void OnEnable()
    {
        _actionController.AddAction<string>("UserName", reactGUI.ReactFunc_UserNameSample, false);
        _actionController.AddAction<int>("Gold", reactGUI.ReactFunc_GoldSample, true);
        _actionController.AddAction<int>("Diamond", reactGUI.ReactFunc_DiaSample, true);
    }

    private void OnDisable()
    {
        _actionController.RemoveAction<string>("UserName", reactGUI.ReactFunc_UserNameSample);
        _actionController.RemoveAction<int>("Gold", reactGUI.ReactFunc_GoldSample);
        _actionController.RemoveAction<int>("Diamond", reactGUI.ReactFunc_DiaSample);
    }

    private void Start()
    {
    }
}
