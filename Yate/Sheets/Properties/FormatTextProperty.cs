using System;
using CsQuery;

namespace Yate.Sheets.Properties
{
    public class FormatTextProperty : IProperty
    {
        private readonly IValue _text;
        private readonly IValue _format;

        public FormatTextProperty(IValue text)
            : this(text, null)
        {
        }

        public FormatTextProperty(IValue text, IValue format)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            _text = text;
            _format = format;
        }

        public void Render(CQ dom, string selector, IYateDataContext dataContext)
        {
            string format;

            if (_format != null)
            {
                format = _format.GetValue(dataContext).ToString();
            }
            else
            {
                format = dom.Select(selector).Text();
            }

            dom.Select(selector).Text(
                string.Format(format, _text.GetValue(dataContext)));
        }
    }
}