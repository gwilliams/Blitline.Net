namespace Blitline.Net.Functions.Builders
{
    public class UnsharpMaskFunctionBuilder : FunctionBuilder<UnsharpMaskFunction>
    {
        public UnsharpMaskFunctionBuilder WithSigma(decimal sigma)
        {
            BuildImp.Sigma = sigma;
            return this;
        }

        public UnsharpMaskFunctionBuilder WithRadius(decimal radius)
        {
            BuildImp.Radius = radius;
            return this;
        }

        public UnsharpMaskFunctionBuilder WithAmount(decimal amount)
        {
            BuildImp.Amount = amount;
            return this;
        }

        public UnsharpMaskFunctionBuilder WithThreshold(decimal threshold)
        {
            BuildImp.Threshold = threshold;
            return this;
        }
    }
}
