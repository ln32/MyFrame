using DataSet;

public class Managing_Currency_Int : ManagingEnumData<Currency_Old, int>
{
    internal override bool IsAvailable(int input)
    {
        return input >= 0;
    }
}

public class Managing_VisualType_String : ManagingEnumData<VisualType_Old, string>
{
    internal override bool IsAvailable(string input)
    {
        return true;
    }
}

public class Managing_TestEnum_Int : ManagingEnumData<TestEnum, int>
{
    internal override bool IsAvailable(int input)
    {
        return input >= 0;
    }
}