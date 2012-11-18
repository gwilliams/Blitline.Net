namespace Blitline.Net.Functions.Builders
{
    public class SharpenFunctionBuilder : FunctionBuilder<SharpenFunction>
    {
        public SharpenFunctionBuilder()
        {
            Function = new SharpenFunction();
        }

        public SharpenFunctionBuilder WithSigma(decimal sigma)
        {
            ((SharpenFunction)Function).Sigma = sigma;
            return this;
        }

        public SharpenFunctionBuilder WithRadius(decimal radius)
        {
            ((SharpenFunction)Function).Radius = radius;
            return this;
        }

        protected override SharpenFunction BuildImp()
        {
            return (SharpenFunction)Function;
        }
    }
}
