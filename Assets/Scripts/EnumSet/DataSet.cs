using UnityEngine;

namespace DataSet
{
    public class ProfileData
    {
        ObservingData<string> ServerName { get; set; }
        ObservingData<string> UID { get; set; }

        ObservingData<Sprite> ProfileImg { get; set; }
        ObservingData<string> Name { get; set; }

        ObservingData<GenderSet> Gender { get; set; }
        ObservingData<MbtiSet> Mbti { get; set; }
        ObservingData<LivePlaceSet> LivePlace { get; set; }
        ObservingData<string> IntroduceComment { get; set; }


        ObservingData<Sprite> SubProfile_1 { get; set; }
        ObservingData<Sprite> SubProfile_2 { get; set; }
        ObservingData<Sprite> SubProfile_3 { get; set; }

        ObservingData<InterestFlagSet> InterestFlag { get; set; }

        ObservingData<VisualDataSet> VisualData { get; set; }
    }


    // int 이벤트성(탈것 신물 스킨.. )
    public enum PlayerGrowth
    {
        ExpriencePoint,
        CharPoint,
        SkillPoint
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
}