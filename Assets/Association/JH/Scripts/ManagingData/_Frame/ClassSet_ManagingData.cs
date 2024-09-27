using DataSet;

public class Managing_PlayerGrowth_Int : ManagingEnumData<PlayerGrowth, int>
{
    internal override bool IsAvailable(int input)
    {
        return input >= 0;
    }
}

public class Managing_VisualType_String : ManagingEnumData<VisualType, string>
{
    internal override bool IsAvailable(string input)
    {
        return true;
    }
}

public class Managing_TestEnum_Int : ManagingEnumData<DataEnum, int>
{
    internal override bool IsAvailable(int input)
    {
        return input >= 0;
    }
}