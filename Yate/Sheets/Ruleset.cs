using System.Collections.Generic;
using CsQuery;

namespace Yate.Sheets
{
    public class RuleSet
    {
        public IList<IProperty> Properties { get; private set; }
        public IList<string> Selectors { get; private set; }

        public RuleSet()
            : this(new List<string>())
        {
        }

        public RuleSet(IList<string> selectors)
            : this(selectors, new List<IProperty>())
        {
        }

        public RuleSet(IList<string> selectors, IList<IProperty> properties)
        {
            if (selectors == null)
            {
                selectors = new List<string>();
            }
            if (properties == null)
            {
                properties = new List<IProperty>();
            }

            Selectors = selectors;
            Properties = properties;
        }

        public virtual void Render(CQ html, IYateDataContext dataContext)
        {
            foreach (var declaration in Properties)
            {
                foreach (var selector in Selectors)
                {
                    declaration.Render(html, selector, dataContext);
                }
            }
        }
    }
}