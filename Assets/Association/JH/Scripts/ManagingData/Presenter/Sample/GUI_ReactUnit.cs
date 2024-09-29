using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class GUI_ReactUnit : MonoBehaviour
{
    [field: SerializeField] public TMP_Text goldText { get; private set; }
    [field: SerializeField] public TMP_Text diamondText { get; private set; }

    public void ReactFunc_GoldSample2(int input)
    {
        goldText.text = input + "";
    }

    public void ReactFunc_DiaSample(int input)
    {
        diamondText.text = input + "";
    }
}
