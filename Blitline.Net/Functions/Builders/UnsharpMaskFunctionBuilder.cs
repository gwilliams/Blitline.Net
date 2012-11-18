namespace Blitline.Net.Functions.Builders
{
    public class UnsharpMaskFunctionBuilder : FunctionBuilder<UnsharpMaskFunction>
    {
        public UnsharpMaskFunctionBuilder()
        {
            Function = new UnsharpMaskFunction();
        }

        public UnsharpMaskFunctionBuilder WithSigma(decimal sigma)
        {
            ((UnsharpMaskFunction) Function).Sigma = sigma;
            return this;
        }

        public UnsharpMaskFunctionBuilder WithRadius(decimal radius)
        {
            ((UnsharpMaskFunction) Function).Radius = radius;
            return this;
        }

        public UnsharpMaskFunctionBuilder WithAmount(decimal amount)
        {
            ((UnsharpMaskFunction) Function).Amount = amount;
            return this;
        }

        public UnsharpMaskFunctionBuilder WithThreshold(decimal threshold)
        {
            ((UnsharpMaskFunction) Function).Threshold = threshold;
            return this;
        }
        
        protected override UnsharpMaskFunction BuildImp()
        {
            return (UnsharpMaskFunction) Function;
        }
    }
}
