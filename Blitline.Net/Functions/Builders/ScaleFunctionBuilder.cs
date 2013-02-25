namespace Blitline.Net.Functions.Builders
{
    public class ScaleFunctionBuilder : FunctionBuilder<ScaleFunction>
    {
        public ScaleFunctionBuilder WithWidth(int width)
        {
            BuildImp.Width = width;
            return this;
        }

        public ScaleFunctionBuilder WithHeight(int height)
        {
            BuildImp.Height = height;
            return this;
        }

        public ScaleFunctionBuilder WithScaleFactor(decimal scaleFactor)
        {
            BuildImp.ScaleFactor = scaleFactor;
            return this;
        }
    }
}
