using System;
using System.Collections.Generic;
using System.Linq;
using CsQuery;

namespace Yate.Rendering
{
    public interface IRenderingRule
    {
        //todo: remove dependency on CQs declaration and selector
        void Render(CQ dom);
    }

    public interface IYateExpression
    {
        IList<ITerm> Terms { get; }
        void Render(CQ html);
    }

    public interface ITerm
    {
        object GetValue();
    }

    public class StringTerm : ITerm
    {
        private readonly string _value;

        public StringTerm(string value)
        {
            _value = value;
        }

        public object GetValue()
        {
            return _value;
        }
    }

    public interface IFunctionTerm : ITerm
    {
        IList<ITerm> Terms { get; }
    }

    public abstract class BaseFunctionTerm : IFunctionTerm
    {
        private readonly IList<ITerm> _terms;

        protected BaseFunctionTerm(IList<ITerm> terms)
        {
            //functions are not garunteed to have terms.
            if (terms == null)
            {
                terms = new List<ITerm>();
            }

            _terms = terms;
        }

        public abstract object GetValue();

        public IList<ITerm> Terms
        {
            get
            {
                return _terms;
            }
        }
    }

    public class TrueFunctionTerm : BaseFunctionTerm
    {
        public TrueFunctionTerm()
            : base(new List<ITerm>())
        {
        }

        public override object GetValue()
        {
            return true;
        }
    }

    public class FalseFunctionTerm : BaseFunctionTerm
    {
        public FalseFunctionTerm()
            : base(new List<ITerm>())
        {
        }

        public override object GetValue()
        {
            return false;
        }
    }


    public class IfFunctionTerm : BaseFunctionTerm
    {
        // if(boolValue,ifTrue[,ifFalse])
        public IfFunctionTerm(IList<ITerm> terms)
            : base(terms)
        {
        }

        public override object GetValue()
        {
            //todo: ERROR CHECKING FOOL!
            if ((bool)Terms[0].GetValue())
            {
                return Terms[1].GetValue();
            }
            else
            {
                return Terms[2].GetValue();
            }
        }
    }

    public class ConcatFunctionTerm : BaseFunctionTerm
    {
        public ConcatFunctionTerm(List<ITerm> terms)
            : base(terms)
        {
        }
        
        public override object GetValue()
        {
            return Terms.Aggregate(string.Empty, (current, term) => current + term.GetValue());
        }
    }

}