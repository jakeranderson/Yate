using System.Xml;

namespace Yate.ValueGetters
{
    internal class XmlNodeValueGetter : ValueGetter
    {
        internal static XmlNodeValueGetter GetXmlNodeValueGetter(object target, string name)
        {
            if (target is XmlNode)
            {
                return new XmlNodeValueGetter((XmlNode)target, name);
            }

            return null;
        }

        private readonly XmlNode _target;
        private readonly string _name;

        private XmlNodeValueGetter(XmlNode target, string name)
        {
            _target = target;
            _name = name;
        }

        public override object GetValue()
        {
            if (_name[0] == '@')
            {
                if (_target.Attributes != null)
                {
                    XmlNode attribute = _target.Attributes.GetNamedItem(_name.Substring(1));

                    if (attribute != null)
                    {
                        return attribute.Value;
                    }
                }
            }
            else
            {
                XmlNodeList list = _target.SelectNodes(_name);

                if (list != null && list.Count > 0)
                {
                    return list;
                }
            }

            return NoValue;
        }
    }
}