using System;

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
}
