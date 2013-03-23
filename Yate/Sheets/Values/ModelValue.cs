using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yate.Sheets.Values
{
    public class ModelFunctionValue : IFunctionValue
    {
        private readonly IValue _pathValue;

        public ModelFunctionValue(IValue pathValue)
        {
            if (pathValue == null)
            {
                throw new ArgumentNullException("pathValue");
            }

            _pathValue = pathValue;
        }

        public object GetValue(IYateDataContext dataContext)
        {
            return dataContext.GetValue(_pathValue.GetValue(dataContext).ToString());
        }
    }

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
