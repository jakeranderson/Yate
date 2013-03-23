using System;
using System.Collections.Generic;
using CsQuery;

namespace Yate.Sheets
{
    public class Declaration
    {
        public IList<IProperty> Properties { get; private set; }

        public Declaration()
            : this(new List<IProperty>())
        {
        }

        public Declaration(IList<IProperty> properties)
        {
            if (properties == null)
            {
                throw new ArgumentNullException("properties");
            }

            Properties = properties;
        }

        public void Render(CQ html, string selector)
        {
            foreach (var property in Properties)
            {
                property.Render(html, selector);
            }
        }

    }
}
