using TMPro;
using UnityEngine;

public class UIView : MonoBehaviour
{
    public ManangingData<int> targetData;
    public TextMeshProUGUI textMeshPro;

    private void OnEnable()
    {
        targetData.onChange += UpdateHpUI;
    }

    private void OnDisable()
    {
        DataManager.instance.Currency.Set(CurrencyType.Gold, 10);
    }

    int temp => DataManager.instance.Currency.Get(CurrencyType.Gold);
    [ContextMenu("AddEvent")]
    private void AddEvent()
    {
        targetData.onChange += UpdateHpUI;
        Debug.Log(temp + " <<");
    }

    [ContextMenu("RemoveEvent")]
    private void RemoveEvent()
    {
        targetData.onChange -= UpdateHpUI;
    }

    [ContextMenu("RemoveEvent")]
    private void ChangeEvent()
    {
        targetData.onChange -= UpdateHpUI;
        DataManager.instance.Currency.Set(CurrencyType.Gold, 10);
    }

    public void UpdateHpUI(int hp)
    {
        textMeshPro.text = hp + "";
    }
}   