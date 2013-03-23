namespace Yate.Rendering.Rules
{
    public class TextRenderingRuleBuilder : IRenderingRuleBuilder<TextRenderingRule>
    {
        public TextRenderingRule Build(RenderingParameters parameters)
        {
            return new TextRenderingRule(parameters);
        }
    }
}