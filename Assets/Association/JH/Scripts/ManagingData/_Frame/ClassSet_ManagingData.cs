using DataSet;

public class Managing_PlayerGrowth_Int : ManagingEnumData<PlayerGrowth, int>
{
    // 0 이하 유효성 체크
    internal override bool IsAvailable(PlayerGrowth index, int input, bool semicheck = true)
    {
        if (input < 0)
        {
            if (semicheck && IsAvailable(index, 0, false))
                Set(index, 0);
            return false;
        }

        return true;
    }
}

public class Managing_VisualType_String : ManagingEnumData<VisualType, string>
{
    // 길이 제한
    internal override bool IsAvailable(VisualType index, string input, bool semicheck = true)
    {
        if (input.Length > 10)
        {
            if (semicheck && IsAvailable(index, "too long",false))
                Set(index, "too long");

            return false;
        }

        return true;
    }
}

public class Managing_DataEnum_Int : ManagingEnumData<DataEnum, int>
{
    // 최소값 이하시 최소값으로 갱신
    internal override bool IsAvailable(DataEnum index, int input, bool semicheck = true)
    {
        int Range_min = 1;

        if (input < Range_min)
        {
            if (semicheck && IsAvailable(index, Range_min, false))
                Set(index, Range_min);

            return false;
        }

        return true;
    }
}


