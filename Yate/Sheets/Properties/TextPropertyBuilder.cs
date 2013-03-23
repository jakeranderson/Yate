using System.Collections.Generic;

namespace Yate.Sheets.Properties
{
    public class TextPropertyBuilder : IPropertyBuilder<TextProperty>
    {
        public TextProperty Build(IList<IValue> values)
        {
            return new TextProperty(values);
        }
    }
}