using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class GUI_ReactUnit : MonoBehaviour
{
    [field: SerializeField] public TMP_Text goldText { get; private set; } 
    [field: SerializeField] public TMP_Text diamondText { get; private set; }
    [field: SerializeField] public Image ImageUI { get; private set; }

    // 동기화 diamondText - dia value
    public void ReactFunc_GoldSample(int input)
    {
        goldText.text = input + "";
    }
    

    // 걍 보여주기용 debug log 
    public void ReactFunc_GoldSample_nonPram()
    {
        Debug.Log(" nonPram Called !!!!");
    }


    // 동기화 diamondText - dia value
    public void ReactFunc_DiaSample(int input)
    {
        diamondText.text = input + "";
    }



    // 동기화 ImageUI - SpriteSync
    public void ReactFunc_SpriteSync(Sprite input)
    {
        ImageUI.sprite = input;
        Debug.Log(input?.name);
    }
}
