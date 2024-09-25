using System;
using TMPro;
using UnityEngine;

public class ObservingGUI_Generial<TEnum>
{
    internal ObservingGUI myGUI;
    internal TEnum type;

    // Fix Text 수정을 위한 함수, Ruby Dia 등등...
    internal void SetType(ObservingGUI insGUI, TEnum _type, int value)
    {
        myGUI = insGUI;
        TextMeshProUGUI[] textComponents = myGUI.GetComponentsInChildren<TextMeshProUGUI>();

        if (textComponents.Length >= 2)
        {
            myGUI.fixedTMP = textComponents[0];  // 첫 번째 자식 TextMeshProUGUI
            myGUI.valueTMP = textComponents[1];  // 두 번째 자식 TextMeshProUGUI
        }
        else
        {
            Debug.LogError("TextMeshProUGUI 컴포넌트가 충분하지 않습니다.");
        }

        myGUI.transform.name = _type.ToString();
        myGUI.fixedTMP.text = _type.ToString() + " : ";
        myGUI.valueTMP.text = value + "";

        myGUI.valueTMP.ForceMeshUpdate();
    }
}