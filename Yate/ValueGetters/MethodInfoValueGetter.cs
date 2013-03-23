using System.Reflection;

namespace Yate.ValueGetters
{
    internal class MethodInfoValueGetter : ValueGetter
    {
        internal static MethodInfoValueGetter GetMethodInfoValueGetter(object target, string name)
        {
            MemberInfo[] methods = target.GetType().GetMember(name, MemberTypes.Method, DefaultBindingFlags);

            foreach (MethodInfo method in methods)
            {
                if (MethodCanGetValue(method))
                {
                    return new MethodInfoValueGetter(target, method);
                }
            }

            return null;
        }

        private static bool MethodCanGetValue(MethodInfo method)
        {
            return method.ReturnType != typeof(void) &&
                   method.GetParameters().Length == 0;
        }

        private readonly object _target;
        private readonly MethodInfo _methodInfo;

        private MethodInfoValueGetter(object target, MethodInfo methodInfo)
        {
            _target = target;
            _methodInfo = methodInfo;
        }

        public override object GetValue()
        {
            return _methodInfo.Invoke(_target, null);
        }
    }
}