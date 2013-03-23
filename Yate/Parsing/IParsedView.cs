using System.IO;

namespace Yate.Parsing
{
    public interface IParsedView
    {
        string Render(IYateDataContext dataContext);
        void WriteToTextWriter(TextWriter textWriter, IYateDataContext dataContext);
    }
}