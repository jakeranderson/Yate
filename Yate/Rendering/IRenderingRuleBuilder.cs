namespace Yate.Rendering
{
    public interface IRenderingRuleBuilder<out T> where T : IRenderingRule
    {
        T Build(RenderingParameters parameters);
    }
}