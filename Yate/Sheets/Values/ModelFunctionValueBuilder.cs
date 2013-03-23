using System.Collections.Generic;
using System.Linq;

namespace Yate.Sheets.Values
{
    public class ModelFunctionValueBuilder : IFunctionValueBuilder<ModelFunctionValue>
    {
        public ModelFunctionValue Build(IList<IValue> values)
        {
            //todo: all sorts of validation for this.
            //what if there are none?
            //what if it doesnt resolve?
            //what if there are over one?
            return new ModelFunctionValue(values.First());
        }
    }
}