using System.Collections.Generic;
using CsQuery;

namespace Yate.Sheets.AtRules
{
    internal class TemplateAtRule : IAtRule
    {
        public IList<IAtRule> AtRules { get; set; }
        public IList<RuleSet> RuleSets { get; set; }

        public void Render(CQ html, IYateDataContext dataContext)
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