using System.Reflection;

namespace Yate.ValueGetters
{
    internal class FieldInfoValueGetter : ValueGetter
    {
        internal static FieldInfoValueGetter GetFieldInfoValueGetter(object target, string name)
        {
            FieldInfo field = target.GetType().GetField(name, DefaultBindingFlags);

            if (field != null)
            {
                return new FieldInfoValueGetter(target, field);
            }

            return null;
        }

        private readonly object _target;
        private readonly FieldInfo _fieldInfo;

        private FieldInfoValueGetter(object target, FieldInfo fieldInfo)
        {
            _target = target;
            _fieldInfo = fieldInfo;
        }

        public override object GetValue()
        {
            return _fieldInfo.GetValue(_target);
        }
    }
}