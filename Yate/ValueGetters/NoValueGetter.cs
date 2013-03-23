namespace Yate.ValueGetters
{
    internal class NoValueGetter : ValueGetter
    {
        public override object GetValue()
        {
            return NoValue;
        }
    }
}