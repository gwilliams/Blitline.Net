namespace Blitline.Net.Functions.Builders
{
    public class ContrastStretchChannelFunctionBuilder : FunctionBuilder<ContrastStretchChannelFunction>
    {
        public ContrastStretchChannelFunctionBuilder WithBlackPoint(int blackPoint)
        {
            BuildImp.BlackPoint = blackPoint;
            return this;
        }

        public ContrastStretchChannelFunctionBuilder WithWhitePoint(int whitePoint)
        {
            BuildImp.WhitePoint = whitePoint;
            return this;
        }
    }
}
