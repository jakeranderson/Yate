using System.Collections.Generic;
using Yate.Sheets;

namespace Yate
{
    public interface IYateDataContext
    {
        object GetValue(string path);
        IDictionary<string, IPattern> PatternContainer { get; }
        void PushValue(object model);
        void PopValue();
    }
}