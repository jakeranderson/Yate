namespace Yate.Sheets.Values
{
    public class StringValue : IValue
    {
        private readonly string _value;

        public StringValue(string value)
        {
            _value = value;
        }

        public object GetValue(IYateDataContext dataContext)
        {
            return _value;
        }
    }
}