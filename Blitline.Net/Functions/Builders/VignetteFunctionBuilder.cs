namespace Blitline.Net.Functions.Builders
{
    public class VignetteFunctionBuilder : FunctionBuilder<VignetteFunction>
    {
        public VignetteFunctionBuilder WithColour(string colour)
        {
            BuildImp.Colour = colour;
            return this;
        }
        
        public VignetteFunctionBuilder WithPosition(int x, int y)
        {
            BuildImp.X = x;
            BuildImp.Y = y;
            return this;
        }

        public VignetteFunctionBuilder WithThreshold(decimal threshold)
        {
            BuildImp.Threshold = threshold;
            return this;
        }

        public VignetteFunctionBuilder WithSigma(decimal sigma)
        {
            BuildImp.Sigma = sigma;
            return this;
        }

        public VignetteFunctionBuilder WithRadius(decimal radius)
        {
            BuildImp.Radius = radius;
            return this;
        }
    }
}
