using System.Collections.Generic;

namespace Yate.Sheets.Values
{
    public class ConcatFunctionValueBuilder : IFunctionValueBuilder<ConcatFunctionValue>
    {
        public ConcatFunctionValue Build(IList<IValue> values)
        {
            return new ConcatFunctionValue(values);
        }
    }
}