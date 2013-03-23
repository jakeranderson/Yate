using System;
using CsQuery;

namespace Yate.Sheets.Properties
{
    public class AttributeProperty : IProperty
    {
        private readonly IValue _attributeName;
        private readonly IValue _attributeValue;

        public AttributeProperty(IValue name, IValue value)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            _attributeName = name;
            _attributeValue = value;
        }

        public void Render(CQ dom, string selector, IYateDataContext dataContext)
        {
            //todo:figure out append, prepend, etc
            dom.Select(selector).Attr(_attributeName.GetValue(dataContext).ToString(), _attributeValue.GetValue(dataContext).ToString());
        }
    }
}