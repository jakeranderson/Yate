using System;
using System.Linq;
using CsQuery;

namespace Yate.Rendering.Rules
{
    public class TextRenderingRule : IRenderingRule
    {
        private readonly RenderingParameters _renderingParameters;

        public TextRenderingRule(RenderingParameters renderingParameters)
        {
            if (renderingParameters == null) throw new ArgumentNullException("renderingParameters");

            _renderingParameters = renderingParameters;
        }

        public void Render(CQ dom)
        {
            foreach (var selector in _renderingParameters.Selectors)
            {
                ////todo: figure out prepend and such
                //if (renderingParameters.Expressions.Count() > 1)
                //{
                //    var method = renderingParameters.Expressions[1].ToLower();
                //    if (method == "append")
                //    {
                //        dom.Select(selector).Text(dom.Select(selector).Text() + renderingParameters.Expressions.FirstOrDefault());
                //    }
                //    else if (method == "prepend")
                //    {
                //        dom.Select(selector).Text(renderingParameters.Expressions.FirstOrDefault() + dom.Select(selector).Text());
                //    }
                //    else
                //    {
                //        dom.Select(selector).Text(renderingParameters.Expressions.FirstOrDefault());
                //    }
                //}
                //else
                //{
                dom.Select(selector).Text(_renderingParameters.Expressions.FirstOrDefault());
                //}
            }
        }
    }
}