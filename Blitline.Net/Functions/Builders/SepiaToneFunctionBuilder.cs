namespace Blitline.Net.Functions.Builders
{
    public class SepiaToneFunctionBuilder : FunctionBuilder<SepiaToneFunction>
    {
        public SepiaToneFunctionBuilder WithThreshold(int thresold)
        {
            BuildImp.Threshold = thresold;
            return this;
        }
    }
}
