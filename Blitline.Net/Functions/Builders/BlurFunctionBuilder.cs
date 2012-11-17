namespace Blitline.Net.Functions.Builders
{
    public class BlurFunctionBuilder : FunctionBuilder<BlurFunction>
    {
        public BlurFunctionBuilder()
        {
            Function = new BlurFunction();
        }

        public BlurFunctionBuilder WithSigma(decimal sigma)
        {
            ((BlurFunction) Function).Sigma = sigma;
            return this;
        }

        public BlurFunctionBuilder WithRadius(decimal radius)
        {
            ((BlurFunction) Function).Radius = radius;
            return this;
        }

        protected override BlurFunction BuildImp()
        {
            return (BlurFunction) Function;
        }
    }
}
