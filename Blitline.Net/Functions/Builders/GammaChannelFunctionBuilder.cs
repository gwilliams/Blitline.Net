namespace Blitline.Net.Functions.Builders
{
    public class GammaChannelFunctionBuilder : FunctionBuilder<GammaChannelFunction>
    {
        public GammaChannelFunctionBuilder WithGamma(decimal gamma)
        {
            BuildImp.Gamma = gamma;
            return this;
        }
    }
}
