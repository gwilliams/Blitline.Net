namespace Blitline.Net.Functions.Builders
{
    public class ContrastStretchChannelFunctionBuilder : FunctionBuilder<ContrastStretchChannelFunction>
    {
        public ContrastStretchChannelFunctionBuilder()
        {
            Function = new ContrastStretchChannelFunction();
        }

        public ContrastStretchChannelFunctionBuilder WithBlackPoint(int blackPoint)
        {
            ((ContrastStretchChannelFunction) Function).BlackPoint = blackPoint;
            return this;
        }

        public ContrastStretchChannelFunctionBuilder WithWhitePoint(int whitePoint)
        {
            ((ContrastStretchChannelFunction)Function).WhitePoint = whitePoint;
            return this;
        }

        protected override ContrastStretchChannelFunction BuildImp()
        {
            return (ContrastStretchChannelFunction) Function;
        }
    }
}
