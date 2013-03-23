using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsQuery;

namespace Yate.Sheets.AtRules
{
    class IfAtRule : IAtRule
    {
        private readonly IValue _conditionValue;
        public IList<IAtRule> AtRules { get; private set; }
        public IList<RuleSet> RuleSets { get; private set; }

        public IfAtRule(IValue conditionValue)
        {
            if (conditionValue == null)
            {
                throw new ArgumentNullException("conditionValue");
            }

            AtRules = new List<IAtRule>();
            RuleSets = new List<RuleSet>();

            _conditionValue = conditionValue;
        }

        public void Render(CQ html, IYateDataContext dataContext)
        {
            if ((bool)_conditionValue.GetValue(dataContext))
            {
                foreach (var atRule in AtRules)
                {
                    atRule.Render(html, dataContext);
                }

                foreach (var ruleSet in RuleSets)
                {
                    ruleSet.Render(html, dataContext);
                }
            }
        }
    }
}
