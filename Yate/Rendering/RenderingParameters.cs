using System.Collections.Generic;

namespace Yate.Rendering
{
    public class RenderingParameters
    {
        public RenderingParameters()
        {
            Selectors = new List<string>();
            Expressions = new List<string>();
        }

        public List<string> Selectors { get; set; }
        public List<string> Expressions { get; set; }
    }
}