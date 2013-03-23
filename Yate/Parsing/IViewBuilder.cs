using Yate.Sheets;

namespace Yate.Parsing
{
    public interface IViewBuilder
    {
        void AddValueBuilder(string keyword, IFunctionValueBuilder<IFunctionValue> value);
        void AddPropertyBuilder(string keyword, IPropertyBuilder<IProperty> propertyBuilder);
        IParsedView Build(string filepath);
    }
}