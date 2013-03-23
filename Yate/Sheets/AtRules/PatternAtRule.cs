using System;
using System.Collections.Generic;
using CsQuery;

namespace Yate.Sheets.AtRules
{
    internal class PatternAtRule : IAtRule
    {
        private readonly IValue _name;
        private readonly IValue _selector;

        public IList<IAtRule> AtRules { get; set; }
        public IList<RuleSet> RuleSets { get; set; }

        public PatternAtRule(IValue name, IValue selector)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            _name = name;
            _selector = selector;

            AtRules = new List<IAtRule>();
            RuleSets = new List<RuleSet>();
        }

        public void Render(CQ html, IYateDataContext dataContext)
        {
            var selector = _selector.GetValue(dataContext).ToString();
            var patterns = html.Select(selector);

            var patternHtml = CQ.CreateFragment(patterns.First());

            dataContext.PatternContainer.Add(
                _name.GetValue(dataContext).ToString(),
                new YatePattern(patternHtml, AtRules, RuleSets));

            html.Select(selector).Remove();
        }
    }
}