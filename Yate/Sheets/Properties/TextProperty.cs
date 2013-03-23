using System.Collections.Generic;
using CsQuery;

namespace Yate.Sheets.Properties
{
    public class TextProperty : BaseProperty
    {
        public TextProperty(IList<IValue> values)
            : base(values)
        {
        }

        public override void Render(CQ dom, string selector, IYateDataContext dataContext)
        {
            //todo:figure out append, prepend, etc
            dom.Select(selector).Text(Values[0].GetValue(dataContext).ToString());
        }
    }
}