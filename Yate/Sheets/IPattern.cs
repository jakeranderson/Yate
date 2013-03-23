using CsQuery;

namespace Yate.Sheets
{
    public interface IPattern : IBlockStructure
    {
        CQ HtmlFragment { get; }
    }
}