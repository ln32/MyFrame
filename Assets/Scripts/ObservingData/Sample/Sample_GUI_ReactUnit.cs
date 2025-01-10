using TMPro;
using UnityEngine;

public class Sample_GUI_ReactUnit : MonoBehaviour
{
    [field: SerializeField] public TMP_Text usernameText { get; private set; }
    [field: SerializeField] public TMP_Text goldText { get; private set; }
    [field: SerializeField] public TMP_Text diamondText { get; private set; }

    // 동기화 NameText - User Name
    public void ReactFunc_UserNameSample(string input)
    {
        usernameText.text = input + "";
    }

    // 동기화 GoldText - Gold value
    public void ReactFunc_GoldSample(int input)
    {
        goldText.text = input + "";
    }

    // 동기화 DiamondText - Dia value
    public void ReactFunc_DiaSample(int input)
    {
        diamondText.text = input + "";
    }
}