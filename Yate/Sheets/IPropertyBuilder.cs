using System.Collections.Generic;

namespace Yate.Sheets
{
    public interface IPropertyBuilder<out T>where T : IProperty
    {
        T Build(IList<IValue> values);
    }
}