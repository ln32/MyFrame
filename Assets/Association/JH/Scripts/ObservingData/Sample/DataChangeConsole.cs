using UnityEngine;

public class DataChangeConsole : MonoBehaviour
{
    private iDataHandler _data => data; [SerializeField] private ObservingDataHandler data;

    public string valueName;

    public string value_str;
    public int value_int;
    public Sprite value_sprite;

    // valueName의 key값을 string 데이터를 변환value_str로 변환
    public void SetValue_string()
    {
        _data.SetValue(valueName, value_str);
    }

    // valueName의 key값을가진 int 데이터를 value_int로 변환
    public void SetValue_int()
    {
        _data.SetValue(valueName, value_int);
    }

    // valueName의 key값을가진 sprite 데이터를 value_sprite로 변환
    public void SetValue_Sprite()
    {
        _data.SetValue(valueName, value_sprite);
    }
}
