using CsQuery;

namespace Yate.Sheets
{
    public interface IAtRule : IBlockStructure
    {
        void Render(CQ html, IYateDataContext dataContext);
    }
}