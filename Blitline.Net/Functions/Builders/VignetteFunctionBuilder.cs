namespace Blitline.Net.Functions.Builders
{
    public class VignetteFunctionBuilder : FunctionBuilder<VignetteFunction>
    {
        public VignetteFunctionBuilder()
        {
            Function = new VignetteFunction();
        }

        public VignetteFunctionBuilder WithColour(string colour)
        {
            ((VignetteFunction) Function).Colour = colour;
            return this;
        }
        
        public VignetteFunctionBuilder WithPosition(int x, int y)
        {
            ((VignetteFunction) Function).X = x;
            ((VignetteFunction) Function).Y = y;
            return this;
        }

        public VignetteFunctionBuilder WithThreshold(decimal threshold)
        {
            ((VignetteFunction) Function).Threshold = threshold;
            return this;
        }

        public VignetteFunctionBuilder WithSigma(decimal sigma)
        {
            ((VignetteFunction) Function).Sigma = sigma;
            return this;
        }

        public VignetteFunctionBuilder WithRadius(decimal radius)
        {
            ((VignetteFunction) Function).Radius = radius;
            return this;
        }

        protected override VignetteFunction BuildImp()
        {
            return (VignetteFunction) Function;
        }
    }
}
