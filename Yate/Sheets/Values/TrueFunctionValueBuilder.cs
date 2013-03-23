using System.Collections.Generic;

namespace Yate.Sheets.Values
{
    public class TrueFunctionValueBuilder : IFunctionValueBuilder<TrueFunctionValue>
    {
        public TrueFunctionValue Build(IList<IValue> values)
        {
            return new TrueFunctionValue();
        }
    }
}