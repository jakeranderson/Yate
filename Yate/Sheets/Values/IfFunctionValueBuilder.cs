using System;
using System.Collections.Generic;

namespace Yate.Sheets.Values
{
    public class IfFunctionValueBuilder : IFunctionValueBuilder<IfFunctionValue>
    {
        public IfFunctionValue Build(IList<IValue> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            if (values.Count < 2)
            {
                throw new ArgumentException("You need at least two values for an if function", "values");
            }

            if (values.Count == 2)
            {
                return new IfFunctionValue(values[0], values[1]);
            }

            return new IfFunctionValue(values[0], values[1], values[2]);
        }
    }
}