namespace Blitline.Net.Functions.Builders
{
    public class BackgroundColorFunctionBuilder : FunctionBuilder<BackgroundColorFunction>
    {
        public BackgroundColorFunctionBuilder WithColor(string color)
        {
            BuildImp.Colour = color;
            return this;
        }
    }
}