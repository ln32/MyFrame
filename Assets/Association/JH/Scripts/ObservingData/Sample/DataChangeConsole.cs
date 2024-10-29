using DataSet;
using UnityEngine;

public class DataChangeConsole : MonoBehaviour
{
    public string valueName;

    public string value_str;
    public int value_int;
    public Sprite value_sprite;

    // valueName의 key값을 string 데이터를 변환value_str로 변환
    public void SetValue_string()
    {
        DataManager.instance.UserProfile.SetValue(UserProfileData.UserName, value_str);
    }

    // valueName의 key값을가진 int 데이터를 value_int로 변환
    public void SetValue_int()
    {
        DataManager.instance.Currency.SetValue(CurrencyData.GoldCoin, value_int);
    }

    // valueName의 key값을가진 sprite 데이터를 value_sprite로 변환
    public void SetValue_Sprite()
    {
        //_data.SetValue(valueName, value_sprite);
    }
}
