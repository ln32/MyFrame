using DataSet;
using static UnityEngine.Rendering.DebugUI;

public class Managing_PlayerGrowth_Int : ManagingEnumData<PlayerGrowth, int>
{
    internal override bool IsAvailable(PlayerGrowth index, int input)
    {
        if (input < 0)
        {
            Set(index, 0);
            return false;
        }

        return true;
    }
}

public class Managing_VisualType_String : ManagingEnumData<VisualType, string>
{
    internal override bool IsAvailable(VisualType index, string input)
    {
        if (input.Length > 10)
        {
            Set(index, "too long");
            return false;
        }

        return true;
    }
}

public class Managing_DataEnum_Int : ManagingEnumData<DataEnum, int>
{
    internal override bool IsAvailable(DataEnum index, int input)
    {
        int Range_min = 1;

        if (input < Range_min)
        {
            Set(index, Range_min);
            return false;
        }

        return true;
    }
}