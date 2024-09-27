using UnityEngine;

namespace DataSet
{
    public class ProfileData
    {
        ManagingData<string> ServerName { get; set; }
        ManagingData<string> UID { get; set; }

        ManagingData<Sprite> ProfileImg { get; set; }
        ManagingData<string> Name { get; set; }

        ManagingData<GenderSet> Gender { get; set; }
        ManagingData<MbtiSet> Mbti { get; set; }
        ManagingData<LivePlaceSet> LivePlace { get; set; }
        ManagingData<string> IntroduceComment { get; set; }


        ManagingData<Sprite> SubProfile_1 { get; set; }
        ManagingData<Sprite> SubProfile_2 { get; set; }
        ManagingData<Sprite> SubProfile_3 { get; set; }

        ManagingData<InterestFlagSet> InterestFlag { get; set; }

        ManagingData<VisualDataSet> VisualData { get; set; }
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