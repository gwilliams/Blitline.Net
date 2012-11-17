namespace Blitline.Net.Functions.Builders
{
    public class GammaChannelFunctionBuilder : FunctionBuilder<GammaChannelFunction>
    {
        public GammaChannelFunctionBuilder()
        {
            Function = new GammaChannelFunction();
        }

        public GammaChannelFunctionBuilder WithGamma(decimal gamma)
        {
            ((GammaChannelFunction) Function).Gamma = gamma;
            return this;
        }

        protected override GammaChannelFunction BuildImp()
        {
            return (GammaChannelFunction) Function;
        }
    }
}
