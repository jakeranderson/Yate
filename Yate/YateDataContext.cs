using System.Collections.Generic;
using Yate.Sheets;
using Yate.ValueGetters;

namespace Yate
{
    //Taken from https://github.com/jdiamond/Nustache/blob/master/Nustache.Core/RenderContext.cs
    public class YateDataContext : IYateDataContext
    {
        private readonly Stack<object> _dataStack = new Stack<object>();

        public YateDataContext(object model)
        {
            PatternContainer = new Dictionary<string, IPattern>();
            _dataStack.Push(model);
        }

        public object GetValue(string path)
        {
            if (path == ".")
            {
                return _dataStack.Peek();
            }

            foreach (var data in _dataStack)
            {
                if (data != null)
                {
                    var value = GetValueFromPath(data, path);

                    if (!ReferenceEquals(value, ValueGetter.NoValue))
                    {
                        return value;
                    }
                }
            }

            return null;
        }

        public IDictionary<string, IPattern> PatternContainer { get; private set; }

        public void PushValue(object model)
        {
            _dataStack.Push(model);
        }

        public void PopValue()
        {
            if (_dataStack.Count > 0)
            {
                _dataStack.Pop();
            }
        }

        private static object GetValueFromPath(object data, string path)
        {
            var names = path.Split('.');

            foreach (var name in names)
            {
                data = ValueGetter.GetValue(data, name);

                if (data == null || ReferenceEquals(data, ValueGetter.NoValue))
                {
                    break;
                }
            }

            return data;
        }
    }
}
