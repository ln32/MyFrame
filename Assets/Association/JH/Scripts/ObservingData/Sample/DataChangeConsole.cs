using UnityEngine;

public class DataChangeConsole : MonoBehaviour
{
    [SerializeField] private ObservingDataHandler data;
    private iDataHandler _data => data;

    public string valueName;

    public string value_str;
    public int value_int;
    public Sprite value_sprite;

    public void SetValue_string()
    {
        data.SetValue(valueName, value_str);
    }

    public void SetValue_int()
    {
        data.SetValue(valueName, value_int);
    }

    public void SetValue_Sprite()
    {
        data.SetValue(valueName, value_sprite);
    }
}
