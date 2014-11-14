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
            BuildImp.Sigma = sigma;
            return this;
        }

        public BlurFunctionBuilder WithRadius(decimal radius)
        {
            BuildImp.Radius = radius;
            return this;
        }
    }
}
