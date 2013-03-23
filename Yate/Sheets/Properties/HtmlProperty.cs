using System;
using CsQuery;

namespace Yate.Sheets.Properties
{
    public class HtmlProperty : IProperty
    {
        private readonly IValue _htmlValue;

        public HtmlProperty(IValue htmlValue)
        {
            if (htmlValue == null)
            {
                throw new ArgumentNullException("htmlValue");
            }

            _htmlValue = htmlValue;
        }

        public void Render(CQ dom, string selector, IYateDataContext dataContext)
        {
            //todo:figure out append, prepend, etc
            dom.Select(selector).Html(_htmlValue.GetValue(dataContext).ToString());
        }
    }
}