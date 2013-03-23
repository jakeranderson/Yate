using System;
using System.Collections.Generic;

namespace Yate.Sheets.Properties
{
    internal class ApplyPatternPropertyBuilder : IPropertyBuilder<ApplyPatternProperty>
    {
        public ApplyPatternProperty Build(IList<IValue> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            if (values.Count < 2)
            {
                throw new ArgumentException("to apply a pattern we need a model and a pattern name", "values");
            }

            return new ApplyPatternProperty(values[0], values[1]);
        }
    }
}