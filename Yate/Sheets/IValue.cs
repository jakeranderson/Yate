namespace Yate.Sheets
{
    public interface IValue
    {
        object GetValue(IYateDataContext dataContext);
    }
}