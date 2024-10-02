using DataSet;
using System;
using UnityEngine;


internal class ProfileData
{
    internal ManagingData<Sprite> _profileImg = new();

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
