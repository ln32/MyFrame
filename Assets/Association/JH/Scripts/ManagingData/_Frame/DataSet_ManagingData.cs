using DataSet;

public class ManagingCurrencyInt : ManagingEnumData<CurrencyType_Int,int>
{
    internal override bool IsAvailable(int input)
    {
        return input >= 0;
    }
}

public class ManagingVisualTypeString : ManagingEnumData<VisualType_String, string> {
    internal override bool IsAvailable(string input)
    {
        return true;
    }
}
