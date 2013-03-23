using System.Collections.Generic;

namespace Yate.Sheets
{
    public interface IFunctionValueBuilder<out T> where T : IFunctionValue
    {
        T Build(IList<IValue> values);
    }
}