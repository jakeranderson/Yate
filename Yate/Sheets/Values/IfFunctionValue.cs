using System;

namespace Yate.Sheets.Values
{
    public class IfFunctionValue : IFunctionValue
    {
        private readonly IValue _conditioinValue;
        private readonly IValue _trueConditionValue;
        private readonly IValue _falseConditionValue;

        // if(conditioinValue,ifTrue[,ifFalse])
        public IfFunctionValue(IValue conditioinValue, IValue trueConditionValue)
            : this(conditioinValue, trueConditionValue, null)
        {
        }

        public IfFunctionValue(IValue conditioinValue, IValue trueConditionValue, IValue falseConditionValue)
        {

            if (conditioinValue == null)
            {
                throw new ArgumentNullException("conditioinValue");
            }
            if (trueConditionValue == null)
            {
                throw new ArgumentNullException("trueConditionValue");
            }
            if (falseConditionValue == null)
            {
                falseConditionValue = new StringValue("");
            }

            _conditioinValue = conditioinValue;
            _trueConditionValue = trueConditionValue;
            _falseConditionValue = falseConditionValue;
        }

        public object GetValue(IYateDataContext dataContext)
        {
            if ((bool)_conditioinValue.GetValue(dataContext))
            {
                return _trueConditionValue.GetValue(dataContext);
            }

            return _falseConditionValue.GetValue(dataContext);
        }
    }
}