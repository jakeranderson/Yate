using System;
using System.Collections.Generic;
using CsQuery;

namespace Yate.Sheets
{
    public class YatePattern : IPattern
    {
        public YatePattern(CQ htmlFragment)
            : this(htmlFragment, null, null)
        {
        }

        public YatePattern(CQ htmlFragment, IList<IAtRule> atRules, IList<RuleSet> ruleSets)
        {
            if (htmlFragment == null)
            {
                throw new ArgumentNullException("htmlFragment");
            }

            if (atRules == null)
            {
                atRules = new List<IAtRule>();
            }
            if (ruleSets == null)
            {
                ruleSets = new List<RuleSet>();
            }

            AtRules = atRules;
            RuleSets = ruleSets;
            HtmlFragment = htmlFragment;
        }

        public IList<IAtRule> AtRules { get; private set; }
        public IList<RuleSet> RuleSets { get; private set; }
        public CQ HtmlFragment { get; private set; }
    }
}