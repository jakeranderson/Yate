namespace Yate.Sheets.Values
{
    public class FalseFunctionValue : IFunctionValue
    {
        public object GetValue(IYateDataContext dataContext)
        {
            return false;
        }
    }
}