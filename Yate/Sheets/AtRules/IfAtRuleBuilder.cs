using System;
using System.Collections.Generic;

namespace Yate.Sheets.AtRules
{
    class IfAtRuleBuilder : IAtRuleBuilder<IfAtRule>
    {
        public IfAtRule Build(IList<IValue> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            if (values.Count < 1)
            {
                throw new ArgumentException("values must have a conditional value", "values");
            }

            return new IfAtRule(values[0]);
        }
    }
}