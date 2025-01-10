using System.Collections.Generic;
using UnityEngine;

public class PrototypeProcessor : MonoBehaviour
{
    public List<CommandUnit> toggleList = new();
    private int currentIndex = -1;

    private void Update()
    {
        // 마우스 클릭 시 이벤트 실행
        if (Input.GetMouseButtonDown(0)) // 0은 좌클릭
            ExecuteNextEvent();
    }

    private void ExecuteNextEvent()
    {
        currentIndex = (currentIndex + 1) % toggleList.Count;
        ChangeView();
    }

    private void ChangeView()
    {
        for (var i = 0; i < toggleList.Count; i++) toggleList[i].SetActiveFalse_Func();

        toggleList[currentIndex].InvokeFunc();
    }
}