namespace Blitline.Net.Functions.Builders
{
    public class SharpenFunctionBuilder : FunctionBuilder<SharpenFunction>
    {
        public SharpenFunctionBuilder WithSigma(decimal sigma)
        {
            BuildImp.Sigma = sigma;
            return this;
        }

        public SharpenFunctionBuilder WithRadius(decimal radius)
        {
            BuildImp.Radius = radius;
            return this;
        }
    }
}
