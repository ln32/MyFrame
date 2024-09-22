using System;

public enum GenderSet
{
    Male,
    Female
}

public enum MbtiSet
{
    ENTP,
    INTP
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
