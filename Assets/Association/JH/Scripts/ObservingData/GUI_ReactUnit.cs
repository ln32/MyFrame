using TMPro;
using UnityEngine;

public class GUI_ReactUnit : MonoBehaviour
{
    public ObservingDataHandler data;
    iActionHandler _actionController;
    [field: SerializeField] public TMP_Text goldText { get; private set; } 
    [field: SerializeField] public TMP_Text diamondText { get; private set; }


    private void Start()
    {
        _actionController.AddAction<int>("Gold",ReactFunc_GoldSample);
        _actionController.AddAction<int>("Diamond", ReactFunc_DiaSample);
    }

    // 동기화 diamondText - dia value
    public void ReactFunc_GoldSample(int input)
    {
        goldText.text = input + "";
    }

    // 동기화 diamondText - dia value
    public void ReactFunc_DiaSample(int input)
    {
        diamondText.text = input + "";
    }
}
