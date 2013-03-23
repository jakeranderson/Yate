using CsQuery;

namespace Yate.Sheets
{
    public interface IProperty
    {
        //todo: remove dependency on CQs declaration and selector
        void Render(CQ html, string selector, IYateDataContext dataContext);
    }
}