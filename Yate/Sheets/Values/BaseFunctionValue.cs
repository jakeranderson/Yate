using System.Collections.Generic;

namespace Yate.Sheets.Values
{
    public abstract class BaseFunctionValue : IFunctionValue
    {
        private readonly IList<IValue> _terms;

        protected BaseFunctionValue(IList<IValue> terms)
        {
            //functions are not garunteed to have terms.
            if (terms == null)
            {
                terms = new List<IValue>();
            }

            _terms = terms;
        }

        public abstract object GetValue();

        public IList<IValue> Terms
        {
            get
            {
                return _terms;
            }
        }
    }
}