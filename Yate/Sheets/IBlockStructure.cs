using System.Collections.Generic;

namespace Yate.Sheets
{
    public interface IBlockStructure
    {
        IList<IAtRule> AtRules { get; }
        IList<RuleSet> RuleSets { get; }
    }
}