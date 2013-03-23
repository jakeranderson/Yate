using System;
using System.Collections.Generic;
using System.Text;

namespace Yate.Sheets.Values
{
    public class ConcatFunctionValue : IFunctionValue
    {
        private readonly IList<IValue> _values;

        public ConcatFunctionValue(IList<IValue> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            _values = values;
        }

        public object GetValue(IYateDataContext dataContext)
        {
            var retVal = new StringBuilder();

            foreach (var value in _values)
            {
                retVal.Append(value.GetValue(dataContext));
            }

            return retVal.ToString();
        }
    }
}