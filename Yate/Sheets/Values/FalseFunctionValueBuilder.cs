using System.Collections.Generic;

namespace Yate.Sheets.Values
{
    public class FalseFunctionValueBuilder : IFunctionValueBuilder<FalseFunctionValue>
    {
        public FalseFunctionValue Build(IList<IValue> values)
        {
            return new FalseFunctionValue();
        }
    }
}