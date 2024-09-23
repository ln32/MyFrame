using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataSet
{
    public class ProfileData
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

    public enum DefaultCurrency
    {
        //ruby
        GoldCoin = 1,
        RubiCoin = 2,
        DiamondCoin = 3,

        EquipGachaTicket = 101,
        PetGachaTicket = 102,
        SkillGachaTicket = 103,


        PickupGachaTicket = 201
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

    namespace UserCharactor
    {
 


        // int 이벤트성(탈것 신물 스킨.. )
        public enum PlayerGrowth
        {
            ExpriencePoint,
            CharPoint,
            SkillPoint
        }
    }

    namespace RewardListup
    {

        // int 이벤트성(탈것 신물 스킨.. )
        public enum UsualFieldReward
        {
            UsualFieldReward_1,
            UsualFieldReward_2,
            UsualFieldReward_3
        }

        public enum EventReward
        {
            EventReward_1,
            EventReward_2,
            EventReward_3
        }

        public enum DungeonReward
        {
            DungeonReward_1,
            DungeonReward_2,
            DungeonReward_3
        }

        public enum BossRaidReward
        {
            BossRaidReward_1,
            BossRaidReward_2,
            BossRaidReward_3
        }
    }
}