using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataSet
{
    public interface IProfileDataHandler
    {
        string ServerName { get; set; }
        string UID { get; set; }

        Sprite ProfileImg { get; set; }
        string Name { get; set; }

        GenderSet Gender { get; set; }
        MbtiSet Mbti { get; set; }
        LivePlaceSet LivePlace { get; set; }
        string IntroduceComment { get; set; }


        Sprite SubProfile_1 { get; set; }
        Sprite SubProfile_2 { get; set; }
        Sprite SubProfile_3 { get; set; }

        InterestFlagSet InterestFlag { get; set; }

        VisualDataSet VisualData { get; set; }
    }

    public interface ICurrencyDataHandler
    {
        int Get(CurrencyType type);
        void Set(CurrencyType type, int value);
    }


}

public enum CurrencyType
{
    Gold,
    Dia,
    Ruby,
    Ticket_0,
    Ticket_1,
    Ticket_2
}

public enum VisualType
{
    BaseCostume, 
    BaseJob,
    BaseColor,
    WeaponType,
    DecorHair,
    DecorFace,
    PersonalityTitle,
    PersonalityFrame,
    PersonalityBubble,
    MiscMount,
    Costume
}
