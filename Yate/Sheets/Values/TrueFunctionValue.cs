namespace Yate.Sheets.Values
{
    public class TrueFunctionValue : IFunctionValue
    {
        public object GetValue(IYateDataContext dataContext)
        {
            return true;
        }
    }
}