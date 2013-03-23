using System;
using System.Collections.Generic;

namespace Yate.Sheets.AtRules
{
    internal class PatternAtRuleBuilder : IAtRuleBuilder<IAtRule>
    {
        public IAtRule Build(IList<IValue> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            if (values.Count < 2)
            {
                throw new ArgumentException("patterns need a name and selector values", "values");
            }

            return new PatternAtRule(values[0], values[1]);
        }
    }
}