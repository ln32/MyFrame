using System;
using UnityEngine;

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

internal class ProfileDataHandler : MonoBehaviour, IProfileDataHandler
{

    [SerializeField] private string _ServerName;
    [SerializeField] private string _UID;
    [Header("- Default Exposure")]
    [SerializeField] private Sprite _profileImg;
    [SerializeField] private string _name;
    [SerializeField] private GenderSet _gender;
    [SerializeField] private MbtiSet _mbti;
    [SerializeField] private LivePlaceSet _livePlace;
    [SerializeField] private string _introduceComment;
    [Header("- Profile Details")]
    [SerializeField] private Sprite _subProfile_1;
    [SerializeField] private Sprite _subProfile_2;
    [SerializeField] private Sprite _subProfile_3;
    [Header("- Extra Details")]
    [SerializeField] private InterestFlagSet _interestFlag;
    [SerializeField] private VisualDataSet _visualData;


    public string ServerName {  get { return _ServerName; } set { _ServerName = value; } }

    public string UID { get { return _UID; } set { _UID = value; } }

    public Sprite ProfileImg { get { return _profileImg; } set { _profileImg = value; } }

    public string Name { get { return _name; } set { _name = value; } }

    public GenderSet Gender { get { return _gender; } set { _gender = value; } }

    public MbtiSet Mbti { get { return _mbti; } set { _mbti = value; } }

    public LivePlaceSet LivePlace { get { return _livePlace; } set { _livePlace = value; } }

    public string IntroduceComment { get { return _introduceComment; } set { _introduceComment = value; } }

    public Sprite SubProfile_1 { get { return _subProfile_1; } set { _subProfile_1 = value; } }

    public Sprite SubProfile_2 { get { return _subProfile_2; } set { _subProfile_2 = value; } }

    public Sprite SubProfile_3 { get { return _subProfile_3; } set { _subProfile_3 = value; } }

    public InterestFlagSet InterestFlag { get { return _interestFlag; } set { _interestFlag = value; } }

    public VisualDataSet VisualData { get { return _visualData; } set { _visualData = value; } }
}
public enum GenderSet
{
    Male,
    Female
}

public enum MbtiSet
{
    entp,
    intp
}

public enum LivePlaceSet
{
    Seoul,
    Busan
}

[Flags]
public enum InterestFlagSet
{
    None = 0,
    Game = 1 << 0,  // 0001
    Sports = 1 << 1,  // 0010
    Meetings = 1 << 2,  // 0100
    Movies = 1 << 3   // 1000
}

[Serializable]
public class VisualDataSet
{
    public int BaseCostume { get; set; }          // 기본 - 코스튬
    public int BaseJob { get; set; }              // 기본 - 직업
    public int BaseColor { get; set; }            // 기본 - 발색
    public int WeaponType { get; set; }           // 무기 - 일반 or 신물
    public int DecorHair { get; set; }            // 꾸밈 - 머리
    public int DecorFace { get; set; }            // 꾸밈 - 얼굴
    public int PersonalityTitle { get; set; }     // 개성 - 칭호
    public int PersonalityFrame { get; set; }     // 개성 - 프레임
    public int PersonalityBubble { get; set; }    // 개성 - 말풍선
    public int MiscMount { get; set; }            // 기타 – 탈것
    public int Costume { get; set; }              // 코스튬
}
