using System.Collections.Generic;

namespace Yate.Sheets
{
    public interface IAtRuleBuilder<out T> where T : IAtRule
    {
        T Build(IList<IValue> values);
    }
}