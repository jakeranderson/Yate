using System;
using System.Collections.Generic;
using CsQuery;

namespace Yate.Sheets.Properties
{
    public abstract class BaseProperty : IProperty
    {
        private readonly IList<IValue> _values;

        protected BaseProperty(IList<IValue> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            _values = values;
        }

        public IList<IValue> Values
        {
            get
            {
                return _values;
            }
        }

        public abstract void Render(CQ html, string selector, IYateDataContext dataContext);
    }
}