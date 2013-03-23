//using CsQuery;

//namespace Yate
//{
//    public class AttributeRenderingRule : IRenderingRule
//    {
//        public void Render(CQ dom, RenderingParameters renderingParameters)
//        {
//            var name = renderingParameters.Expressions[0];
//            var value = renderingParameters.Expressions[1];

//            foreach (var selector in renderingParameters.Selectors)
//            {
//                dom.Select(selector).Attr(name, value);
//            }
//        }
//    }
//}